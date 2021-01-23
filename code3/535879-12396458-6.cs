    private const int Iterations = 100000000;
    static void Test(Action a)
    {
        // Start the stopwatch.
        Stopwatch s = Stopwatch.StartNew();
        // Loop
        for (int i = 0; i < Iterations; ++i)
        {
            // Perform the action.
            a();
        }
        // Write the time.
        Console.WriteLine("Time: {0} ms", s.ElapsedMilliseconds);
        // Collect garbage to not interfere with other tests.
        GC.Collect();
    }
