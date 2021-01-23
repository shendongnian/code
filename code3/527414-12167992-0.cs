    static void f(params object[] x)
    {
        Console.WriteLine(x.Length);
    }
    public static void Main()
    {
        object[] x = { 1, 2 };
        f(x);
    }
