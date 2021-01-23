    2: 2.76665
    3: 5.5382
    4: 8.30805
    5: 11.13095
    6: 13.8864
    7: 16.6808
    8: 13.8722
    9: 11.14495
    10: 8.3409
    11: 5.5631
    12: 2.76775
    public static class Program
    {
        private const int Max = 2000000;
        private static readonly object Lock = new object();
        public static void Main()
        {
            var r = new Random();
            var ints = new int[13];
            Parallel.For(0, Max, i =>
            {
                var result = Rand(r, 1, 7) + Rand(r, 1, 7);
                Interlocked.Increment(ref ints[result]);
            });
            for (int i = 0; i < ints.Length; i++)
            {
                Console.WriteLine("{0}: {1}",
                    i, ints[i] / ((double)Max) * 100);
            }
        }
        private static int Rand(Random random, int minValue, int maxValue)
        {
            lock (Lock)
            {
                return random.Next(minValue, maxValue);
            }
        }
    }
