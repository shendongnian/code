    public class A {
      public String MyValue { get; set; }
    }
    
    public class B : A{
      public String AnotherValue { get; set; }
    }
    
    public class C : B {
      public void DoSomething() {
        MyValue = "Hello";
        AnotherValue = "World";
      }
    
      public String Output() {
        return String.Format("{0} {1}", MyValue, AnotherValue);
        
      }
    }
    
    C myObj = new C();
    C.DoSomething();
    String message = C.Output();
    // value of message will be "Hello World"
