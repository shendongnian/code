    class Item
    {
      public string Name{get;set;}
      public Action Action{get;set;}
    
      public override string ToString() { return Name; }
    }
