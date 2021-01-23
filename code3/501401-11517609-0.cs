    static void Main()
    {
        int x = 100;
        double y = 1.2345678;
        var objArgs = new object[] { x, y };
        Action<int, double> a = (i, d) => { };
        var sw = new Stopwatch();
        sw.Start();
        const int loop = 1000000;
        for (int i = 0; i < loop; i++)
            a.DynamicInvoke(objArgs);
        Console.WriteLine("Dynamic: " + sw.ElapsedMilliseconds);
        sw.Stop();
        sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < loop; i++)
            a(x,y);
        Console.WriteLine("Invoke: " + sw.ElapsedMilliseconds);
        sw.Stop();
    }
