    class MyLeaf
    {
      public string LeafName {get; set;}
      public bool LeafValue {get; set;}
    }
    class MyTree
    {
      public string TreeName {get; set;}
      public List<MyLeaf> Leafs = new List<MyLeaf>();
    }
