    class NodeA
    {
        public NodeA() { }
        public NodeA(NodeB node)
        {
            Name = node.Name;
            Children = node.Children.Select(n => new NodeA(n)).ToList();
        }
        public string Name{get;set;}
        public List<NodeA> Children {get;set;}
        // etc some other properties
    }
