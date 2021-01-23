       static void Main(string[] args)
        {
            var barrier = new Barrier(2);
            var collection = new List<int>();
            var num_iterations = 100000;
            var iterations = num_iterations;
            var total_time_ms = 0.0M;
            Stopwatch sw = new Stopwatch();
            total_time_ms = 0.0M;
            iterations = num_iterations;
            var blockingCollection = new BlockingCollection<int>();
            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (iterations-- > 0)
                {
                    sw.Restart();
                    blockingCollection.Add(i++);
                }
            });
            Task.Factory.StartNew(() =>
            {
                var expected_value = 0;
                while (iterations > 0) // stop when performed certain number
                {
                    int i = blockingCollection.Take();
                    sw.Stop();
                    long microseconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
                    total_time_ms += microseconds;
                    if (i != expected_value)
                        Console.WriteLine(String.Format("** expected {0} got {1}", i, expected_value));
                    expected_value++;
                }
            });
            while (iterations > 0)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine(String.Format("Total {0} for {1} iterations, average {2}", total_time_ms, num_iterations, total_time_ms / num_iterations));
