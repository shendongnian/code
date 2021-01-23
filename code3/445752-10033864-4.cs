    public class Graph<T>
    {
        public Dictionary<T, HashSet<T>> nodesNeighbors;
        public IEnumerable<T> Nodes
        {
            get { return nodesNeighbors.Keys; }
        }
        public Graph()
        {
            this.nodesNeighbors = new Dictionary<T, HashSet<T>>();
        }
        public void AddNode(T node)
        {
            this.nodesNeighbors.Add(node, new HashSet<T>());
        }
        public void AddNodes(IEnumerable<T> nodes)
        {
            foreach (var n in nodes)
                this.AddNode(n);
        }
        public void AddArc(T from, T to)
        {
            this.nodesNeighbors[from].Add(to);
            this.nodesNeighbors[to].Add(from);
        }
        public bool ContainsNode(T node)
        {
            return this.nodesNeighbors.ContainsKey(node);
        }
        public IEnumerable<T> GetNeighbors(T node)
        {
            return nodesNeighbors[node];
        }
        public IEnumerable<T> DepthFirstSearch(T nodeStart)
        {
            var stack = new Stack<T>();
            var visitedNodes = new HashSet<T>();
            stack.Push(nodeStart);
            while (stack.Count > 0)
            {
                var curr = stack.Pop();
                if (!visitedNodes.Contains(curr))
                {
                    visitedNodes.Add(curr);
                    yield return curr;
                    foreach (var next in this.GetNeighbors(curr))
                    {
                        if (!visitedNodes.Contains(next))
                            stack.Push(next);
                    }
                }
            }
        }
        public Graph<T> GetSubGraph(IEnumerable<T> nodes)
        {
            Graph<T> g = new Graph<T>();
            g.AddNodes(nodes);
            foreach (var n in g.Nodes.ToList())
            {
                foreach (var neigh in this.GetNeighbors(n))
                    g.AddArc(n, neigh);
            }
            return g;
        }
    
        public IEnumerable<Graph<T>> GetConnectedComponents()
        {
            var visitedNodes = new HashSet<T>();
            var components = new List<Graph<T>>();
    
            foreach (var node in this.Nodes)
            {
                if (!visitedNodes.Contains(node))
                {
                    var subGraph = GetSubGraph(this.DepthFirstSearch(node));
                    components.Add(subGraph);
                    visitedNodes.UnionWith(subGraph.Nodes);
                }
            }
            return components;
        }
    }
