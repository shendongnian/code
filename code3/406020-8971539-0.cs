    void Main()
    {
    	Method<Class1>(); // Outputs Class1
    	Method<Class2>(); // Outputs Class2
    	Method<Class2b>(); // Outputs Class2, because it falls back to the base type
    	Method<Class3>(); // Throws exception
    }
    
    void Method<T>() where T : new()
    {
        dynamic c = new T();
        Method(c);
    }
    
    void Method(Class1 c) { Console.WriteLine("Class1"); }
    void Method(Class2 c) { Console.WriteLine("Class2"); }
    
    class Class1 {}
    class Class2 {}
    class Class2b : Class2 {}
    class Class3 {}
