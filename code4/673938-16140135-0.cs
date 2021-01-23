    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5] { 32, 67, 88, 13, 50 };
            var randomEnumerable = new RandomEnumerable(0, numbers.Length);
            int i = 0;
            while (i < numbers.Length)
            {
                var nextIndex = randomEnumerable.First();
                var number = numbers[nextIndex];
                Console.WriteLine(number);
                i++;
            }
            Console.ReadLine();
        }
    }
    class RandomEnumerable : IEnumerable<int>
    {
        private readonly int _max;
        private readonly int _min;
        private Random _random;
        public RandomEnumerable(int min, int max)
        {
            _max = max;
            _min = min;
            _random = new Random();
        }
        public IEnumerator<int> GetEnumerator()
        {
            while (true)
            {
                yield return _random.Next(_min, _max);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
