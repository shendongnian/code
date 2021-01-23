    class A {
      public void x(){ y(); }
      public virtual void y(){}
    }
    class B : public A {
      public overrides void y() { }; 
      public void a() { x(); }
    };
    B b = new B();
    b.a();
