    {
        Base b = new Base();
        Console.WriteLine(b.Name); // prints "Base"
        b = new Overriden();
        // Base.Name is virtual, so the vtable determines its implementation
        Console.WriteLine(b.Name); // prints "Overriden"
        Overriden o = new Overriden();
        // Overriden.Name is virtual, so the vtable determines its implementation
        Console.WriteLine(o.Name); // prints "Overriden"
    }
