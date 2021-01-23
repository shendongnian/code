    public static class RandomGenerator
    {
        private static object locker = new object();
        private static Random seedGenerator = new Random(Environment.TickCount);
        public static double GetRandomNumber()
        {
            int seed;
            lock (locker)
            {
                seed = seedGenerator.Next(int.MinValue, int.MaxValue);
            }
            var random = new Random(seed);
            return random.NextDouble();
        }
    }
