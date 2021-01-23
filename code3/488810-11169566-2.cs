    class Base {
      public virtual void Method() {
        // ...
      }
    }
    class Derived : Base {
      public override void Method() {
        base.Method();
        // ....
      }
    }
