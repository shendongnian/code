    class NodeA 
    { 
        public string Name{get;set;} 
        public List<NodeA> Children {get;set;} 
          
        // COPY CTOR
        public NodeA(NodeB copy)
        {
            this.Name = copy.Name;
            this.Children = new List<NodeA>(copy.Children.Select(b => new NodeA(b));
            //copy other props
        }
    } 
