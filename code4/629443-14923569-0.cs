    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            foreach (var item in Get().Take(2))
            {
                Console.WriteLine(item);
            }
        }
    
        static IEnumerable<int> Get()
        {
            foreach (var item in new[] { 1, 2, 3 })
            {
                yield return item;
            }
        }
    }
