    class Foo { }
    class Bar : Foo { }
    
    void Do(Foo foo)
    {
         Console.WriteLine("Foo overload");
    }
    
    void Do(Bar bar)
    {
        Console.WriteLine("Bar overload");
    }
