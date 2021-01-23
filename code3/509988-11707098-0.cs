    // Define other methods and classes here
    T Add<T>(dynamic a, dynamic b)
    {
        Console.WriteLine(a.GetType());
        Console.WriteLine(b.GetType());
        return a + b;
    }
