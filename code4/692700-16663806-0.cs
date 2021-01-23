    public static void F<T>(Expression<T> exp, params object[] d)
    {
        Console.WriteLine("begin");
        var del = exp.Compile() as Delegate;
        del.DynamicInvoke(d);
        Console.WriteLine("end");
    }
