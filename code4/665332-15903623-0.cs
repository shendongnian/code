     interface InterfaceA { void doA(); }
    
        class A : InterfaceA { public virtual void doA() { Console.WriteLine("Class A"); } }
    
        interface InterfaceB { void doB(); }
    
        class B : InterfaceB { public virtual void doB() { Console.WriteLine("Class B"); } }
    
        class C : InterfaceA, InterfaceB
        {
            public static void main()
            {
                A _a = new A();
                B _b = new B();
               _a.doA();
                _b.doB();
            }
    
            public void doA()
            {
                throw new NotImplementedException();
            }
    
            public void doB()
            {
                throw new NotImplementedException();
            }
        }
