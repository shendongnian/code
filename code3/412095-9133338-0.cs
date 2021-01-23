    class Node
    {
        public int Key { get; set; }
        public bool IsRoot { get; set; }
        public bool IsLeaf { get; set; }
        private List<Node> children = new List<Node>();
        public List<Node> Children { get { return this.children; } }
    }
