    using System;
    
    class A
    {
        public virtual string Foo() { return "A"; }
    }
    
    class B : A
    {
        public override string Foo() { return "B"; }
    }
    
    class C : B
    {
        public override string Foo() { return "C"; }
    }
    
    class D : C
    {
        public override string Foo() { return "D"; }
        
        public void ShowBaseFoo()
        {
            Console.WriteLine("base.Foo() from D: {0}", base.Foo());
        }
    }
    
    class Test
    {
        static void Main()
        {
            new D().ShowBaseFoo();
        }
    }
