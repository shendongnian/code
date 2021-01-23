    interface A { void Foo(); }
    interface B { void Bar(); }
    class AAdapter : B { 
       private A a;
       public AAdapter(A a) { this.a = a; }
      
       void Bar() {
          a.Foo(); // just pretend foo and bar do the same thing
       } 
    }
