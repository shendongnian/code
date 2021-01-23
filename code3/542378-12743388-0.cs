    var e = default(Action<int>);
    var a = new Action<int>(_ => { });
            
    var s = new Subject<int>();
    var n = new NopObserver<int>();
    var N = 20;
    var M = 10000000;
    var sw = new Stopwatch();
    for (int i = 0; i < N; i++)
    {
        sw.Restart();
        for (int j = 0; j < M; j++)
        {
            var f = e;
            if (f != null)
                f(42);
        }
        sw.Stop();
        var t = sw.Elapsed;
        Console.WriteLine("E({0}) = {1}", i, t);
        sw.Restart();
        for (int j = 0; j < M; j++)
        {
            s.OnNext(42);
        }
        sw.Stop();
        var u = sw.Elapsed;
        Console.WriteLine("O({0}) = {1}", i, u);
        var d = u.TotalMilliseconds / t.TotalMilliseconds;
        Console.ForegroundColor = d <= 1 ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(d + " - " + GC.CollectionCount(0));
        Console.ResetColor();
        Console.WriteLine();
        e += a;
        s.Subscribe(n);
    }
