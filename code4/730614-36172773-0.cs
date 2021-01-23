    namespace TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A();
                a.foo();        // A.foo()
                a.foo2();       // A.foo2()
    
                a = new B();    
                a.foo();        // B.foo()
                a.foo2();       // A.foo2()
                //a.novel() is not available here
    
                a = new C();
                a.foo();        // C.foo()
                a.foo2();       // A.foo2()
    
                B b1 = (B)a;    
                b1.foo();       // C.foo()
                b1.foo2();      // B.foo2()
                b1.novel();     // B.novel()
    
                Console.ReadLine();
            }
        }
    
    
        class A
        {
            public virtual void foo()
            {
                Console.WriteLine("A.foo()");
            }
    
            public void foo2()
            {
                Console.WriteLine("A.foo2()");
            }
        }
    
        class B : A
        {
            public override void foo()
            {
                // This is an override
                Console.WriteLine("B.foo()");
            }
    
            public new void foo2()      // Using the 'new' keyword doesn't make a difference
            {
                Console.WriteLine("B.foo2()");
            }
    
            public void novel()
            {
                Console.WriteLine("B.novel()");
            }
        }
    
        class C : B
        {
            public override void foo()
            {
                Console.WriteLine("C.foo()");
            }
    
            public new void foo2()
            {
                Console.WriteLine("C.foo2()");
            }
        }
    }
