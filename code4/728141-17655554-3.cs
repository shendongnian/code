    static object Locker = new object();
    
    static int GetResultFromResource(int arg)
    {
        lock(Locker)
        {
            Thread.Sleep(500);
            return arg * 2;
        }
    }
    var tasks = Enumerable
              .Range(1, 10)
              .Select(x => Task.Run(() => GetResultFromResource(x)));
    
    foreach(var result in tasks.Select(x => x.Result))
    {
        Console.WriteLine(result);
    }
