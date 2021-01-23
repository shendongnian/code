    static T CastByExample<T>(object obj, T example)
    { 
        return (T)obj; 
    }
    static void M(object obj)
    {
        var anon = CastByExample(obj, new { X = 0 });
        Console.WriteLine(anon.X);  // 123
    }
    static void N()
    {
        M(new { X = 123 });
    }
