    using System;
    using System.Collections.Generic;
    
    namespace SelectQuery
    {
    
        internal static class MyExtensions
        {
            public static IEnumerable<int> Select(this int[] items, Func<int, int> selector)
            {
                return items;
    
            }
        }
    
        class Program
        {
    
            static void Main(string[] args)
            {
                int[] data = new[] { 1, 2, 34 };
    
                var result = from v in data select v;
                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
