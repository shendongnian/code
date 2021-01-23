    public static object Test()
    {
        return new { A = "Test" };
    }
    public static string GetA(object obj)
    {
        // We create an anonymous type of the same type of the one in Test()
        // just to have its type.
        var x = new { A = string.Empty };
        // We pass it to Cast, that will take its T from the type of x
        // and that will return obj casted to the type of the anonymous
        // type
        x = Cast(x, obj);
        // Now in x we have obj, but strongly typed. So x.A is the value we
        // want
        return x.A;
    }
    public static T Cast<T>(T type, object obj) where T : class
    {
        return (T)obj;
    }
    string str = GetA(Test());
