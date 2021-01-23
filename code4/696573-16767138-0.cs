    class Program
    {
        static void Main(string[] args)
        {
            Benchmark(50);
        }
        private static void Benchmark(int iterations)
        {
            int[] list = Enumerable.Range(0, 100000000).ToArray();
            long sum = 0;
            for (int i = 0; i < iterations; i++)
            {
                sum += ArrayForeach(list);
            }
            Console.WriteLine("ForEach " + sum / iterations);
            sum = 0;
            for (int i = 0; i < iterations; i++)
            {
                sum += Foreach(list);
            }
            Console.WriteLine("foreach " + sum / iterations);
        }
        private static long Foreach(int[] list)
        {
            long total = 0;
            var stopWatch = Stopwatch.StartNew();
            foreach (var i in list)
            {
                total += i;
            }
            stopWatch.Stop();
            return stopWatch.ElapsedTicks;
        }
        private static long ArrayForeach(int[] list)
        {
            long total = 0;
            var stopWatch = Stopwatch.StartNew();
            Array.ForEach(list, x => total += x);
            stopWatch.Stop();
            return stopWatch.ElapsedTicks;
        }
    }
