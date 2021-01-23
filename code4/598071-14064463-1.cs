    void X()
    {
        var a = new TypeDict();
        var b = new TypeDict();
        a.Set<int>(1);
        a.Set<double>(3.14);
        a.Set("Hello, world!");
        //Note that type inference allows us to omit the type argument
        b.Set(10);          
        b.Set(31.4);  
        b.Set("Hello, world, times ten!");
        Console.WriteLine(a.Get<int>());
        Console.WriteLine(a.Get<double>());
        Console.WriteLine(a.Get<string>());
        Console.WriteLine();
        Console.WriteLine(b.Get<int>());
        Console.WriteLine(b.Get<double>());
        Console.WriteLine(b.Get<string>());
    }
