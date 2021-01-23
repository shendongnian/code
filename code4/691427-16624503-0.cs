    using System;
    
    public class A // This is the base class.
    {
        public A(int value)
        {
    	// Executes some code in the constructor.
    	Console.WriteLine("Base constructor A()");
        }
    }
    
    public class B : A // This class derives from the previous class.
    {
        public B(int value)
    	: base(value)
        {
    	// The base constructor is called first.
    	// ... Then this code is executed.
    	Console.WriteLine("Derived constructor B()");
        }
    }
    
    class Program
    {
        static void Main()
        {
    	// Create a new instance of class A, which is the base class.
    	// ... Then create an instance of B, which executes the base constructor.
    	A a = new A(0);
    	B b = new B(1);
        }
    }
