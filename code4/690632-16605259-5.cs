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
            // Deal with the case of an empty source (simply return an enumerable containing a single, empty enumerable)
            if (!source.Any())
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
            // Grab the first element off of the list
            var element = source.Take(1);
            // Recurse, to get all subsets of the source, ignoring the first item
            var haveNots = SubSetsOf(source.Skip(1));
            // Get all those subsets and add the element we removed to them
            var haves = haveNots.Select(set => element.Concat(set));
            // Finally combine the subsets that didn't include the first item, with those that did.
            return haves.Concat(haveNots);
        }
    }
