    void Foo(object argument)
    {
        Console.WriteLine("object");
    }
    
    void Foo<T>(IEnumerable<T> argument)
    {
        Console.WriteLine("enumerable T");
    }
    
    void Foo(string argument)
    {
        Console.WriteLine("string");
    }
