    class A
    {
         private Base internalBase;
         public A() { this.internalBase = new Base(); }
         public Foo Method1() { return this.internalBase.Method1(); }
    }
    class B
    {
         private Base internalBase;
         public A() { this.internalBase = new Base(); }
         public Foo Method2() { return this.internalBase.Method2(); }
         public Foo Method3() { return this.internalBase.Method3(); }
    }
    
