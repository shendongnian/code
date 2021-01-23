    static ManualResetEvent _starter = new ManualResetEvent (false);
    
    void Main()
    {
        var regs = Enumerable.Range (0, 20000)
            .Select (_ => ThreadPool.RegisterWaitForSingleObject (_starter, Go, "Some Data", -1, true))
            .ToArray();
    
        Thread.Sleep (5000);
        Console.WriteLine ("Signaling worker...");
        _starter.Set();
        Console.ReadLine();
    
        foreach (var reg in regs) reg.Unregister (_starter);
    }
    
    public static void Go (object data, bool timedOut)
    {
        Console.WriteLine ("Started - " + data);
        // Perform task...
    }
