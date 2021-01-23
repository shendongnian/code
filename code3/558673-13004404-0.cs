    static void Main()
    {
        int x = 0, y = 0, z = 0;
        GetRandomValues(__arglist(ref x, ref y, ref z));
        Console.WriteLine(x);
        Console.WriteLine(y);
        Console.WriteLine(z);
    }
    static void GetRandomValues(__arglist)
    {
        Random random = new Random(1);
        ArgIterator iterator = new ArgIterator(__arglist);
        while (iterator.GetRemainingCount() > 0)
        {
            TypedReference r = iterator.GetNextArg();
            __refvalue(r, int) = random.Next(0, 10);
        }
    }
