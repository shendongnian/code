    public class ZZZ
    {
      public string foo() { return ImAPropertyOfAnAAADerivedClass ? "yes" : "no"; }
      bool ImAPropertyOfAnAAADerivedClass 
      {
          get { return TestForAAA is AAA; }
      }
      
      public object TestForAAA { get; set; }
    }
    
