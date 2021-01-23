    static void Main(string[] args)
    {
        var qs = new List<Action>();
        for (var i = 0; i < 10; i++)
            qs.Add(() => f("doer", i));
        for (var i = 0; i < 10; i++)
            qs[i]();
    }
    private static void f(string x, int y)
    {
        Console.WriteLine("{0}: {1}", x, y);
    }
