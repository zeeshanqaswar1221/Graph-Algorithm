using System;

// https://www.youtube.com/watch?v=tWVWeAqZ0WU&ab_channel=freeCodeCamp.org
// Material to follow

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region BFS AND DFS IMPLEMENTATION
            //Dictionary<char, char[]> graph = new Dictionary<char, char[]>()
            //{
            //    { 'a', new char[]{'b','c'} },
            //    { 'b', new char[]{'d'} },
            //    { 'c', new char[]{'e'} },
            //    { 'd', new char[]{'f'} },
            //    { 'e', new char[]{} },
            //    { 'f', new char[]{} },
            //};

            //DFSTraversal(graph, 'a');
            //BFSTraversal(graph, 'a');

            #endregion

            #region SOLVE HAS PATH PROBLEM
            //Dictionary<char, char[]> graph = new Dictionary<char, char[]>()
            //{
            //    {'f', new char[] {'g', 'i'} },
            //    {'g', new char[] {'h'} },
            //    {'h', new char[] {} },
            //    {'i', new char[] {'g', 'k'} },
            //    {'j', new char[] {'i'} },
            //    {'k', new char[] {} },
            //};
            //Console.WriteLine(HasPath(graph, 'f', 'k'));
            #endregion

            #region UNDIRECTED PATH PROBLEM

            char[][] edges = new char[][]
            {
                new char[]{'i','j' },
                new char[]{'k','i' },
                new char[]{'m','k' },
                new char[]{'k','l' },
                new char[]{'o','n' }
            };

            Console.WriteLine(UndirectedPath(edges, 'j', 'm'));

            #endregion

        }

        //  Utilize Queue
        static void BFSTraversal(Dictionary<char, char[]> graph, char source)
        {
            Queue<char> queue = new Queue<char>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                char current = queue.Dequeue();
                Console.WriteLine(current);

                foreach (var neighbour in graph[current])
                {
                    queue.Enqueue(neighbour);
                }
            }

        }

        //  Utilize Stack
        static void DFSTraversal(Dictionary<char, char[]> graph, char source)
        {
            #region ITERATIVE

            //Stack<char> stack = new Stack<char>();
            //stack.Push(source);

            //while (stack.Count > 0)
            //{
            //    char current = stack.Pop();
            //    Console.WriteLine(current);

            //    foreach (var neighbour in graph[current])
            //    {
            //        stack.Push(neighbour);
            //    }
            //}

            #endregion

            #region RECURSIVE

            Console.WriteLine(source);
            foreach (var neighbour in graph[source])
            {
                DFSTraversal(graph, neighbour);
            }

            #endregion
        }

        //  Find path on Graph (Directed, ACyclic Graph)
        static bool HasPath(Dictionary<char, List<char>> graph, char src, char dst)
        {
            #region RECURSIVE BFS

            //if (src == dst)
            //{
            //    return true;
            //}

            //foreach (var neighbour in graph[src])
            //{
            //    if (HasPath(graph, neighbour, dst))
            //    {
            //        return true;
            //    }
            //}

            //return false;

            #endregion

            #region ITERATIVE DFS

            Queue<char> queue = new Queue<char>();
            queue.Enqueue(src);

            while (queue.Count > 0)
            {
                char current = queue.Dequeue();
                if (current == dst) { return true; }

                foreach (var neighbour in graph[current])
                {
                    queue.Enqueue(neighbour);
                }
            }

            return false;
            #endregion

        }

        static bool UndirectedPath(char[][] edges, char nodeA, char nodeB)
        {
            if (nodeA == nodeB)
            {
                return true;
            }

            // Create graph
            Dictionary<char, List<char>> graph = GenerateGraph(edges);
            //PrintDictionary(graph);

            return HasPath(graph, nodeA, nodeB);
        }

        // From undirected Edges to graph
        static Dictionary<char, List<char>> GenerateGraph(char[][] edges)
        {
            Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();

            foreach (var item in edges)
            {
                if (!graph.ContainsKey(item[0]))
                {
                    graph.Add(item[0], new List<char>());
                }
                
                if (!graph.ContainsKey(item[1]))
                {
                    graph.Add(item[1], new List<char>());
                }
                
                graph[item[0]].Add(item[1]);
                graph[item[1]].Add(item[0]);
            }

            return graph;
        }

        public static void PrintDictionary(Dictionary<char, List<char>> graph)
        {
            foreach (var item in graph)
            {
                string arrayPrint = "[ ";
                foreach (var itemList in graph[item.Key])
                {
                    arrayPrint += $"{itemList}, ";
                }

                arrayPrint.TrimEnd();
                arrayPrint += "]";

                Console.WriteLine($"{item.Key} : {arrayPrint}");
            }
        }

    }
}
