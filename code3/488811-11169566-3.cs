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
    class Derived2 : Derived {
      public override void Method() {
        base.Method();
        // ....
      }
    }
