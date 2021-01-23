    public class Node
    {
        public Node Parent { get; set; }
        public string ParentName { get { Parent != null ? Parent.Name : null; } }
        // ...
    }
