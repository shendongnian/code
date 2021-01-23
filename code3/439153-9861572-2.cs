    class A {
      public void x(){ y(); }
      public void y(){}
    }
    class B : inherits A {
      public void y() { }; 
      public void a() { x(); }
    };
