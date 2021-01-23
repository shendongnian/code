    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[][]
            {
                new [] {14, 24, 44, 36, 37, 45},//- here
                new [] {01, 02, 06, 24, 33, 44},
                new [] {10, 17, 34, 40, 44, 45},//- here
                new [] {12, 13, 28, 31, 37, 47},
                new [] {01, 06, 07, 09, 40, 45},
                new [] {01, 05, 06, 19, 35, 44},
                new [] {13, 19, 20, 26, 31, 47},
                new [] {44, 20, 30, 31, 45, 46},//- here
                new [] {02, 04, 14, 23, 30, 34},
                new [] {27, 30, 41, 42, 44, 49},
                new [] {03, 06, 15, 27, 37, 48},
            };
    
            var matches = new List<int[]>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
    
                    var match = input[i].Intersect(input[j]).ToArray();
                    if (match.Any())
                    {
                        matches.Add(match);
                    }
                }
            }
    
            var comparer = new ArrayComparer<int>();
            var mostCommon = matches
                .Where(p => p.Length > 1)
                .GroupBy(p => p, comparer)
                .OrderByDescending(p => p.Count())
                .ThenByDescending(p => p.Key.Count()).FirstOrDefault();
    
            if (mostCommon != null)
            {
                Console.WriteLine("Most common: {{{0}}}",
                    string.Join(", ", mostCommon.Key));
            }
            else
            {
                Console.WriteLine("Not found.");
            }
        }
    
        public class ArrayComparer<T> : EqualityComparer<IEnumerable<T>>
        {
            public override bool Equals(IEnumerable<T> x, IEnumerable<T> y)
            {
                return x != null && y != null &&
                    (x == y || Enumerable.SequenceEqual(x,y));
            }
    
            public override int GetHashCode(IEnumerable<T> obj)
            {
                if (obj == null || !obj.Any())
                {
                    return 0;
                }
    
                return obj.Sum(p => p.GetHashCode() + p.GetHashCode());
            }
        }
