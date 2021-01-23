    public static object Test()
    {
        return new { A = "Test" };
    }
    public static string GetA(object obj)
    {
        var x = new { A = string.Empty };
        x = Cast(x, obj);
        return x.A;
    }
    public static T Cast<T>(T type, object obj) where T : class
    {
        return (T)obj;
    }
    string str = GetA(Test());
