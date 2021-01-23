    using System;
    
    class Test<T>
    {
        T _value;
    
        public Test(T t)
        {
    	// The field has the same type as the parameter.
    	this._value = t;
        }
    
        public void Write()
        {
    	Console.WriteLine(this._value);
        }
    }
    
    class Program
    {
        static void Main()
        {
    	// Use the generic type Test with an int type parameter.
    	Test<int> test1 = new Test<int>(5);
    	// Call the Write method.
    	test1.Write();
    
    	// Use the generic type Test with a string type parameter.
    	Test<string> test2 = new Test<string>("cat");
    	test2.Write();
        }
    }
