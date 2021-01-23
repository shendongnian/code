    using System;
    using System.Linq;
    
    namespace StackOverflow_2013_05_27_EqualValuesInArray
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] array = { 1, 2, 4, 2, 4 };
    
                var tbl = array
                    .GroupBy(n => n)
                    .Where(g => g.Count() > 1)
                    .ToDictionary(g => g.Key, g => g.Count());
    
                foreach (var pair in tbl)
                    Console.WriteLine("{0} is in array {1} times", pair.Key, pair.Value);
    
                Console.ReadLine();
            }
        }
    }
