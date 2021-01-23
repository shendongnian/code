    private static int called;
    private const int ITERATIONS = 10000;
    private static Stopwatch sw;
    static void Main(string[] args)
    {
        sw = Stopwatch.StartNew();
        var x = Stopwatch.StartNew();
        while (true)
        {
            DoGateIteration();
            x.Restart();
            while (x.ElapsedMilliseconds < 2) ; // busy-wait for 2 ms
        }
    }
    private static void DoGateIteration()
    {
        called++;
        if (called == ITERATIONS)
        {
            Console.WriteLine("Average iterations per second: " + ITERATIONS * 1000 / sw.ElapsedMilliseconds);
            Console.WriteLine("Average iterations milliseconds: " + sw.ElapsedMilliseconds / ITERATIONS);
        }
    }
