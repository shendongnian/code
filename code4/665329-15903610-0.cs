    using System;
    
    interface InterfaceA { void doA(); } 
    
    class A : InterfaceA { public virtual void doA() {Console.WriteLine("Class A");} }
    
    interface InterfaceB { void doB(); }
    
    class B : InterfaceB { public virtual void doB(){ Console.WriteLine("Class B");}}
    
    class C 
    {
       static void doA(A x) { x.doA(); }
       static void doB(B x) { x.doB(); } 
    
      public static void main()
      {
        A _a = new A();
        B _b = new B();
        doA(_a);   
        doB(_b);
      }
    
    }
