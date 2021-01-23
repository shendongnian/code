    interface IEdgeCollection
    {
        bool AddEdge(string node1, string node2);
        bool ContainsEdge(string node1, string node2);
        bool RemoveEdge(string node1, string node2);
    }
    class EdgeSet1 : IEdgeCollection
    {
        private HashSet<string> _edges = new HashSet<string>();
        private static string MakeEdgeKey(string node1, string node2)
        {
            return StringComparer.Ordinal.Compare(node1, node2) < 0 ? node1 + node2 : node2 + node1;
        }
        public bool AddEdge(string node1, string node2)
        {
            var key = MakeEdgeKey(node1, node2);
            return _edges.Add(key);
        }
        public bool ContainsEdge(string node1, string node2)
        {
            var key = MakeEdgeKey(node1, node2);
            return _edges.Contains(key);
        }
        public bool RemoveEdge(string node1, string node2)
        {
            var key = MakeEdgeKey(node1, node2);
            return _edges.Remove(key);
        }
    }
    class EdgeSet2 : IEdgeCollection
    {
        private HashSet<Tuple<string, string>> _edges = new HashSet<Tuple<string, string>>();
        private static Tuple<string, string> MakeEdgeKey(string node1, string node2)
        {
            return StringComparer.Ordinal.Compare(node1, node2) < 0 
                ? new Tuple<string, string>(node1, node2) 
                : new Tuple<string, string>(node2, node1);
        }
        public bool AddEdge(string node1, string node2)
        {
            var key = MakeEdgeKey(node1, node2);
            return _edges.Add(key);
        }
        public bool ContainsEdge(string node1, string node2)
        {
            var key = MakeEdgeKey(node1, node2);
            return _edges.Contains(key);
        }
        public bool RemoveEdge(string node1, string node2)
        {
            var key = MakeEdgeKey(node1, node2);
            return _edges.Remove(key);
        }
    }
    class EdgeSet3 : IEdgeCollection
    {
        private HashSet<Tuple<string, string>> _edges = new HashSet<Tuple<string, string>>();
        private static Tuple<string, string> MakeEdgeKey(string node1, string node2)
        {
            return new Tuple<string, string>(node1, node2);
        }
        public bool AddEdge(string node1, string node2)
        {
            var key1 = MakeEdgeKey(node1, node2);
            var key2 = MakeEdgeKey(node2, node1);
            return _edges.Add(key1) && _edges.Add(key2);
        }
        public bool ContainsEdge(string node1, string node2)
        {
            var key = MakeEdgeKey(node1, node2);
            return _edges.Contains(key);
        }
        public bool RemoveEdge(string node1, string node2)
        {
            var key1 = MakeEdgeKey(node1, node2);
            var key2 = MakeEdgeKey(node2, node1);
            return _edges.Remove(key1) && _edges.Remove(key2);
        }
    }
    
    class Program
    {
        static void Test(string[] nodes, IEdgeCollection edges, int edgeCount)
        {
            // use edgeCount as seed to rng to ensure test reproducibility
            var rng = new Random(edgeCount);
            // store known edges in a separate data structure for validation
            var edgeList = new List<Tuple<string, string>>();
            Stopwatch stopwatch = new Stopwatch();
            // randomly generated edges
            stopwatch.Start();
            for (int i = 0; i < edgeCount; i++)
            {
                string node1 = nodes[rng.Next(nodes.Length)];
                string node2 = nodes[rng.Next(nodes.Length)];
                edges.AddEdge(node1, node2);
                edgeList.Add(new Tuple<string, string>(node1, node2));
            }
            var addElapsed = stopwatch.Elapsed;
            // non random lookups
            int nonRandomFound = 0;
            stopwatch.Start();
            foreach (var edge in edgeList)
            {
                if (edges.ContainsEdge(edge.Item1, edge.Item2))
                    nonRandomFound++;
            }
            var nonRandomLookupElapsed = stopwatch.Elapsed;
            if (nonRandomFound != edgeList.Count)
            {
                Console.WriteLine("The edge collection {0} is not working right!", edges.GetType().FullName);
                return;
            }
            // random lookups
            int randomFound = 0;
            stopwatch.Start();
            for (int i = 0; i < edgeCount; i++)
            {
                string node1 = nodes[rng.Next(nodes.Length)];
                string node2 = nodes[rng.Next(nodes.Length)];
                if (edges.ContainsEdge(node1, node2))
                    randomFound++;
            }
            var randomLookupElapsed = stopwatch.Elapsed;
            // remove all
            stopwatch.Start();
            foreach (var edge in edgeList)
            {
                edges.RemoveEdge(edge.Item1, edge.Item2);
            }
            var removeElapsed = stopwatch.Elapsed;
            Console.WriteLine("Test: {0} with {1} edges: {2}s addition, {3}s non-random lookup, {4}s random lookup, {5}s removal",
                edges.GetType().FullName,
                edgeCount,
                addElapsed.TotalSeconds,
                nonRandomLookupElapsed.TotalSeconds,
                randomLookupElapsed.TotalSeconds,
                removeElapsed.TotalSeconds);
        }
        static void Main(string[] args)
        {
            var rng = new Random();
            var nodes = new string[5000];
            for (int i = 0; i < nodes.Length; i++)
            {
                StringBuilder name = new StringBuilder();
                int length = rng.Next(7, 15);
                for (int j = 0; j < length; j++)
                {
                    name.Append((char) rng.Next(32, 127));
                }
                nodes[i] = name.ToString();
            }
            IEdgeCollection edges1 = new EdgeSet1();
            IEdgeCollection edges2 = new EdgeSet2();
            IEdgeCollection edges3 = new EdgeSet3();
            Test(nodes, edges1, 2000000);
            Test(nodes, edges2, 2000000);
            Test(nodes, edges3, 2000000);
            Console.ReadLine();
        }
    }
