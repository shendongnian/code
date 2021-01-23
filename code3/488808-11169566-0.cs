    class Base {
      public virtual void Method() {
        // ...
      }
    }
    class Derived {
      public override void Method() {
        base.Method();
        // ....
      }
    }
