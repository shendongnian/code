    using System;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var inputArray = Enumerable.Range(1, 10).ToArray()
    
                var grouped = from Groupings in Enumerable.Range(1, inputArray.Length)
                              from IndexInGroup in Enumerable.Range(0, inputArray.Length / Groupings)
                              let StartPosInArray = IndexInGroup * Groupings
                              select new { BucketSize = Groupings, BucketIndex = StartPosInArray, Sum = inputArray.Skip(StartPosInArray).Take(Groupings).Sum() };
    
                foreach (var group in grouped)
                    Console.WriteLine(group);
    
                Console.ReadKey();
            }
        }
    }
