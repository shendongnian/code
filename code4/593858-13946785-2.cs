    class Child {
      public bool IsBeaten { get; private set; }
    
      public void Beat(IChildBeater beater) {
        IsBeaten = true;
      }
    }
    
    class Mother : IChildBeater { ... }
    
    class Father : IChildBeater { ... }
    
    class BullyFromDownTheStreet : IChildBeater { ... }
  
