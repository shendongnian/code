    static void Main(string[] args)
    {
        const int loopCount = 1000000000;
        var s = args.Length > 1 ? args[1] : null; // Compiler knows 's' can be null
        int sum = 0;
    
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
    
        for (int i = 0; i < loopCount; i++)
        {
            sum += (s ?? "o").Length;
        }
    
        watch.Stop();
    
        Console.WriteLine($"?? operator took {watch.ElapsedMilliseconds} ms");
    
        sum = 0;
    
        watch.Restart();
    
        for (int i = 0; i < loopCount; i++)
        {
            sum += (s != null ? s : "o").Length;
        }
    
        watch.Stop();
    
        Console.WriteLine($"null-check condition took {watch.ElapsedMilliseconds} ms");
    }
