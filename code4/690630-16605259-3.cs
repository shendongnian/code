    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class Program
    {
        static void Main(string[] args)
        {
            var test = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var target = 6;
            var matches = from subset in test.SubSetsOf()
                          where subset.Sum() == target
                          select subset;
            Console.WriteLine("Numbers: {0}", test.Select(i => i.ToString()).Aggregate((a, n) => a + ", " + n));
            Console.WriteLine("Target: {0}", target);
            foreach (var match in matches)
            {
                Console.WriteLine(match.Select(m => m.ToString()).Aggregate((a, n) => a + " + " + n) + " = " + target.ToString());
            }
            Console.ReadKey();
        }
        public static IEnumerable<IEnumerable<T>> SubSetsOf<T>(this IEnumerable<T> source)
        {
            if (!source.Any())
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
            var element = source.Take(1);
            var haveNots = SubSetsOf(source.Skip(1));
            var haves = haveNots.Select(set => element.Concat(set));
            return haves.Concat(haveNots);
        }
    }
