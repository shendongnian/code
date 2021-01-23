    static void Main()
    {
        // Valid: uses parameterless overload
        new Thread(new ThreadStart(Foo));
        // Valid: uses parameterized overload
        new Thread(new ParameterizedThreadStart(Foo));
        // Invalid, as there are two valid constructor overloads
        new Thread(Foo);
    }
    
    static void Foo()
    {
    }
    
    static void Foo(object state)
    {
    }
