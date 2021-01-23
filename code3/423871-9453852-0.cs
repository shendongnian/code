    class Node
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public List<Node> Children { get; set; }
        public Node(int min, int max)
        {
            this.Min = min;
            this.Max = max;
            this.Children = new List<Node>();
        }
        public void Add(Node child)
        {
            this.Children.Add(child);
        }
    }
