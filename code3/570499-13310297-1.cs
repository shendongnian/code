    public class Node
    {
        public List<Node> Children { get; set; }
        public List<Node> Parents { get; set; }
        public string Name { get; set; } 
        // whatever
        public Node()
        {
            Children = new List<Node>();
            Parents = new List<Node>();
        }
    }
