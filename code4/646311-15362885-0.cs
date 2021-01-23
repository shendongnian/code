    public interface I {
      int foo();
    }
    
    public class C : I {
      double foo() { return 2.0; }
      int I.foo() { return 4; }
    }
