    public class Tarjan<T>
    {
        private class Node
        {
            public T Value { get; private set; }
            public int Index { get; set; }
            public int LowLink { get; set; }
            public Node(T value)
            {
                this.Value = value;
                this.Index = -1;
                this.LowLink = -1;
            }
        }
        private Func<T, IEnumerable<T>> getSuccessors;
        private Dictionary<T, Node> nodeMaps;
        private int index = 0;
        private Stack<Node> stack;
        private List<List<Node>> SCC;
        public bool HasCycle(IEnumerable<T> nodes, Func<T, IEnumerable<T>> getSuccessors)
        {
            return ExecuteTarjan(nodes, getSuccessors).Any(x => x.Count > 1);
        }
        private List<List<Node>> ExecuteTarjan(IEnumerable<T> nodes, Func<T, IEnumerable<T>> getSuccessors)
        {
            this.nodeMaps = nodes.ToDictionary(x => x, x => new Node(x));
            this.getSuccessors = getSuccessors;
            SCC = new List<List<Node>>();
            stack = new Stack<Node>();
            index = 0;
            foreach (var node in this.nodeMaps.Values)
            {
                if (node.Index == -1)
                    TarjanImpl(node);
            }
            return SCC;
        }
        private IEnumerable<Node> GetSuccessors(Node v)
        {
            return this.getSuccessors(v.Value).Select(x => this.nodeMaps[x]);
        }
        private List<List<Node>> TarjanImpl(Node v)
        {
            v.Index = index;
            v.LowLink = index;
            index++;
            stack.Push(v);
            foreach (var n in GetSuccessors(v))
            {
                if (n.Index == -1)
                {
                    TarjanImpl(n);
                    v.LowLink = Math.Min(v.LowLink, n.LowLink);
                }
                else if (stack.Contains(n))
                {
                    v.LowLink = Math.Min(v.LowLink, n.Index);
                }
            }
            if (v.LowLink == v.Index)
            {
                Node n;
                List<Node> component = new List<Node>();
                do
                {
                    n = stack.Pop();
                    component.Add(n);
                } while (n != v);
                SCC.Add(component);
            }
            return SCC;
        }
    }
