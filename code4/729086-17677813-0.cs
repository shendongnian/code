    using System;
    namespace Override
    {
        class Base 
        {
            public virtual void method() 
            {
                Console.WriteLine("Base method");
            }
        }
        class Derived : Base 
        {
            public override void method()
            {
                Console.WriteLine("Derived method");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Derived d = new Derived();
                Base b = d;
                b.method();
            }
        }
    }
