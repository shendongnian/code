    class A {
    public:
      void x(){ y(); }
      virtual void y(){}
    };
    class B : public A {
    public:
      // virtual not needed here but nice
      virtual void y() { }; 
      void a() { x(); }
    };
    B* b = new B();
    b->a();
