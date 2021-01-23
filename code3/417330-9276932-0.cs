    if (asInt)
    {
        var b = Int64.Parse(a); // will infer a `long`
        Console.WriteLine(b.GetType());
    }
    else
    {
        var b = Double.Parse(a); // will infer a `double`
        Console.WriteLine(b.GetType());
    }
