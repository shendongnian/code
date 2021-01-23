    public class Class1 {
      public Class1(object args): this(new RouteValueDictionary(args)) {}
    
      protected Class1(RouteValueDictionary args) {
        // retrieve any property you need here from args
      }
    }
    
    public class Class2: Class1 {
      public Class2(object args): this(new RouteValueDictionary(args)) {}
    
      protected Class2(RouteValueDictionary args): base(args) {
        // retrieve any property specific to Class2 from args
      }
    }
    
    // etc.
