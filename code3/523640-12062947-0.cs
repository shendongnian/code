    interface INode {
      public string Name{get;set;}
      public IEnumerable<INode> Children {get;set;}
    }
    class NodeA : INode {
      public string Name{get;set;}
      public List<NodeA> Children {get;set;}
      // etc some other properties
    }
    class NodeB : INode {
      public string Name;
      public IEnumerable<NodeB> Children;
      // etc some other fields;
    }
    void myMethod() {
      INode nodeB = new NodeB();
      INode nodeA = nodeB;
    }
    
