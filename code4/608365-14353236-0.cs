    using System;
    
    class Base
    {
        public virtual void Foo()
        {
            Console.WriteLine("Base.Foo");
        }
    }
    
    class Derived : Base
    {
        public override void Foo()
        {
            Console.WriteLine("Derived.Foo");
        }
    }
    
    class MoreDerived : Derived
    {
        public new void Foo()
        {
            Console.WriteLine("MoreDerived.Foo");
        }
    }
    
    class Test
    {
        static void Main()
        {
            Base x = new MoreDerived();
            x.Foo(); // Prints Derived.Foo
        }
    }
