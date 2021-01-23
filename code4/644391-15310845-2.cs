    public class Graph
    {
        public Node Root;
        public List<Node> AllNodes = new List<Node>();
        public Node CreateRoot(string name)
        {
            Root = CreateNode(name);
            return Root;
        }
        public Node CreateNode(string name)
        {
            var n = new Node(name);
            AllNodes.Add(n);
            return n;
        }
        public int?[,] CreateAdjMatrix()
        {
            // Matrix will be created here...
        }
    }
