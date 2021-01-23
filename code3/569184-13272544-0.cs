    public class Node
    {
        public string Name { get; set; } // Current node name
        public string Parent { get; set; }
        public string Keyword { get; set; }
        public int Level { get; set; } // Optional
        
        private List<Node> _children = new List<Node>();
        public List<Node> Children { get { return _children; } }
        
        public Node AddChild(Node child)
        {
            _children.Add(child);
            return this;
        }   
    }
