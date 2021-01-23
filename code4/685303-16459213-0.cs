    class Program
    {
        static void Main(string[] args)
        {
            var arrays = new int[][] {
                new[]{ 1, 12, 10, 2, 23 },
                new[] {14,10,20,4},
                new[] {5, 5, 15, 5},
                new[] {1, 5, 30}
            };
            foreach (var array in arrays)
            {
                Console.WriteLine(String.Format("Results for {0}:", string.Join(",", array)));
                IEnumerable<IEnumerable<int>> partitions = Partition(array);
                if (!partitions.Any()) 
                    Console.WriteLine("Cannot be partitioned.");
                else
                    foreach (var item in partitions)
                    {
                        Console.WriteLine(string.Join(",", item));
                    }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static IEnumerable<IEnumerable<int>> Partition(int[] array)
        {
            var sum = array.Sum();
            if ((sum % 2) == 1) return Enumerable.Empty<IEnumerable<int>>();
            return Subsequences(array).Where(ss => ss.Sum(item => item) == (sum / 2));
        }
        // http://stackoverflow.com/a/3750709/201088
        private static IEnumerable<IEnumerable<T>> Subsequences<T>(IEnumerable<T> source)
        {
            if (source.Any())
            {
                foreach (var comb in Subsequences(source.Skip(1)))
                {
                    yield return comb;
                    yield return source.Take(1).Concat(comb);
                }
            }
            else
            {
                yield return Enumerable.Empty<T>();
            }
        }
    }
