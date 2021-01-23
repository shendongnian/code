    public class UndirectedGraph<T>
    {
        private Dictionary<T, HashSet<T>> linkedNodes = new Dictionary<T, HashSet<T>>();
        public void AddNode(T node)
        {
            if (!linkedNodes.ContainsKey(node))
                linkedNodes.Add(node, new HashSet<T>());
        }
        public void AddArc(T node1, T node2)
        {
            if (!linkedNodes.ContainsKey(node1))
                linkedNodes.Add(node1, new HashSet<T>());
            linkedNodes[node1].Add(node2);
            if (!linkedNodes.ContainsKey(node2))
                linkedNodes.Add(node2, new HashSet<T>());
            linkedNodes[node2].Add(node1);
        }
        public IEnumerable<HashSet<T>> GetConnectedComponents()
        {
            HashSet<T> visitedNodes = new HashSet<T>();
            foreach (T nodeToVisit in linkedNodes.Keys)
            {
                if (!visitedNodes.Contains(nodeToVisit))
                {
                    HashSet<T> connectedComponent = GetConnectedComponent(nodeToVisit);
                    visitedNodes.UnionWith(connectedComponent);
                    yield return connectedComponent;
                }
            }
        }
        private HashSet<T> GetConnectedComponent(T from)
        {
            HashSet<T> result = new HashSet<T>();
            Stack<T> nodesToVisit = new Stack<T>();
            nodesToVisit.Push(from);
            result.Add(from);
            while (nodesToVisit.Count != 0)
            {
                T nodeToVisit = nodesToVisit.Pop();
                foreach (T linkedNode in linkedNodes[nodeToVisit])
                {
                    if (!result.Contains(linkedNode))
                    {
                        nodesToVisit.Push(linkedNode);
                        result.Add(linkedNode);
                    }
                }
            }
            return result;
        }
    }
