    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        internal class Program
        {
            static void Main()
            {
                IList<string> list = new List<string>{"One", "Two", "Three"};
                Print(list);
                Console.WriteLine("---------");
                var someMultiplesOfThree = Enumerable.Range(0, 10).Where(n => (n%3 == 0)).Select(n => n.ToString());
                list.AddRange(someMultiplesOfThree); // Using the extension method.
                // Now list has had some items added to it.
                Print(list);
            }
            static void Print<T>(IEnumerable<T> seq)
            {
                foreach (var item in seq)
                    Console.WriteLine(item);
            }
        }
        // You need a static class to hold the extension method(s):
        public static class IListExt
        {
            // This is your extension method:
            public static IList<T> AddRange<T>(this IList<T> @this, IEnumerable<T> range)
            {
                foreach (var item in range)
                    @this.Add(item);
                return @this;
            }
        }
    }
