    static void MeasuredAction(string message, Action action)
    {
        Console.WriteLine("Started {0}", message);
        var stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        Console.WriteLine("Results of {0} Elapsed {1}", message, stopwatch.Elapsed);
    }
    static void Main(string[] args)
    {
        MeasureAction(delegate()
        {
            // do work
        });
    }
