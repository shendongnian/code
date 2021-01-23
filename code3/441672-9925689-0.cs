      static void Main(string[] args)
            {
                Worker(1); // jit Warmup
                var stopWatchOfStopwatchStopwatch = System.Diagnostics.Stopwatch.StartNew();
                var stopWatchOfLoop = System.Diagnostics.Stopwatch.StartNew();
                Worker(100000000);
                stopWatchOfLoop.Stop();
                Console.WriteLine("Elapsed of inner SW: " + stopWatchOfLoop.Elapsed.ToString());
                stopWatchOfStopwatchStopwatch.Stop();
                Console.WriteLine("Elapsed of outer SW: " + stopWatchOfStopwatchStopwatch.Elapsed.ToString());
    
                var stopwatchOfcompareLoop = System.Diagnostics.Stopwatch.StartNew();
                Worker(100000000);
                stopwatchOfcompareLoop.Stop();
                Console.WriteLine("Elapsed of inner SW: " + stopWatchOfLoop.Elapsed.ToString());
            }
            static void Worker(int iterations)
            {
                for (int i = 0; i < iterations; i++)
                {
                    Console.WriteLine("bla");
                }
            }
