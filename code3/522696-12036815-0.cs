    using System;
    
    public class BaseClass
    {
        public BaseClass(string x, int y)
        {
            Console.WriteLine("Base class constructor");
            Console.WriteLine("x={0}, y={1}", x, y);
        }
    }
    
    public class DerivedClass : BaseClass
    {
        // Chains to the 1-parameter constructor
        public DerivedClass() : this("Foo")
        {
            Console.WriteLine("Derived class parameterless");
        }
        
        public DerivedClass(string text) : base(text, text.Length)
        {
            Console.WriteLine("Derived class with parameter");
        }
            
    }
    
    static class Test
    {
        static void Main()
        {
            new DerivedClass();
        } 
    }
