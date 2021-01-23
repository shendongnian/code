    static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 7).ToArray();
            var originalNumbers = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            var foundAfterListUsingGuid = new List<int>();
            var foundAfterListUsingShuffle = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                var foundAfter = 0;
                while (!originalNumbers.SequenceEqual(numbers.OrderBy(x => Guid.NewGuid())))
                {
                    foundAfter++;                    
                }
                foundAfterListUsingGuid.Add(foundAfter);
                foundAfter = 0;
                var shuffledNumbers = Enumerable.Range(1, 7).ToArray();
                while (!originalNumbers.SequenceEqual(shuffledNumbers))
                {
                    foundAfter++;
                    Shuffle(shuffledNumbers);
                }
                foundAfterListUsingShuffle.Add(foundAfter);
            }
            Console.WriteLine("Average matching order (Guid): {0}", foundAfterListUsingGuid.Average());
            Console.WriteLine("Average matching order (Shuffle): {0}", foundAfterListUsingShuffle.Average());
            Console.ReadKey();
        }
        static Random _random = new Random();
        public static void Shuffle<T>(T[] array)
        {
            var random = _random;
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int j = random.Next(i); // 0 <= j <= i-1
                // Swap.
                T tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
        }
