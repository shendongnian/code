    class Node
    {
        public string Data { get; set; }
        public Node Parent { get; set; }
    
        public Node(string data, Node parent)
        {
            Data = data;
    		Parent = parent;
        }
    }
