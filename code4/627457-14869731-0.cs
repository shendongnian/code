    public abstract class A {
      private readonly BarType _foo;
    
      protected A(BarType foo) {
        _foo = foo;
      }
    
      // Does Foo need to be public or is it only used internally by A?
      public BarType Foo { get { return _foo; } }
    }
    
    public class B : A {
      
      public B() : base(BarType.Value1) {
      }
    }
