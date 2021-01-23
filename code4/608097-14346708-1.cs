    using System;
    
    class Base
    {
        public void Foo(int x)
        {
            Console.WriteLine("Base.Foo(int)");
        }
    }
    
    class Derived : Base
    {
        public void Foo(long y)
        {
            Console.WriteLine("Derived.Foo(long)");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Derived x = new Derived();
            Base y = x;
            x.Foo(5); // Derived.Foo(long)
            y.Foo(5); // Base.Foo(int)
        }
    }
