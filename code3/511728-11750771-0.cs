    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        private static List<T> RunQuery<T>(IEnumerable<T> someCollection, Func<T, bool> predicate)
        {
            List<T> items = new List<T>();
            IEnumerable<T> addItems = someCollection.Where(predicate);
            items.AddRange(addItems);
            return items;
        }
        static void Main()
        {
            var values = Enumerable.Range(0, 1000);
            List<int> results = RunQuery(values, i => i >= 500);
            Console.WriteLine(results.Count);
            Console.WriteLine("Press key to exit:");
            Console.ReadKey();
        }
    }
