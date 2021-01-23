    public class Node
    {
        private List<Node> children = new List<Node>();
    
        /// <summary>
        /// This will have a non-null value if it's a leaf.  It will be null if it's not a leaf.
        /// </summary>
        public int? Value { get; set; } 
    
        public Node this[int index]
        {
            get
            {
                if (children.Count == 0)
                {
                    throw new ArgumentException("This node has no children");
                }
                if (children.Count > index)
                {
                    throw new ArgumentException("This node doesn't have that many children");
                }
    
                return children[index];
            }
        }
    }
