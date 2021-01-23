    var foo = Enumerable.Empty<int?>();
    Console.WriteLine(foo.Min());
    
    foo = new int? [] { null, -20, 10 };
    Console.WriteLine(foo.Min());
    Console.WriteLine(foo.Max());
