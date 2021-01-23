    public static class RandomGenerator
    {
        private static Random seedGenerator = new Random(Environment.TickCount);
        public static double GetRandomNumber()
        {
            int seed = seedGenerator.Next(int.MinValue, int.MaxValue);
            var random = new Random(seed);
            return random.NextDouble();
        }
    }
