    using System;
    
    public delegate void StringAction(string x);
    
    public class Base
    {
        public void Foo(string x)
        {
            Console.WriteLine("Base");
        }
    }
    
    public class Child : Base
    {
        public void Foo(object x)
        {
            Console.WriteLine("Child");
        }
    }
    
    public class Test
    {
        static void Main()
        {
            Child c = new Child();
            StringAction action = new StringAction(c.Foo);
            action("x");
        }
    }
