    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication11
    {
        class Program
        {
            static void Main(string[] args)
            {
                var listA = new List<int> {1, 2, 5, 4, 7, 6, 5, 3};
                var listB = new List<int> {4, 2, 7, 4, 3, 6, 7, 8, 9, 4, 1};
                var itemsInANotInB = listA.Except(listB).ToList();
                var itemsInBNotInA = listB.Except(listA).ToList();
                var listsHaveAllElementsInCommon = !(itemsInANotInB.Any() && itemsInBNotInA.Any());
                var listAreSequenceEqal = listA.SequenceEqual(listB);
                Console.WriteLine("Items in A but not in B: {0}", itemsInANotInB.Select(x=>x.ToString()).Aggregate((x,y) => x+", "+y));
                Console.WriteLine("Items in B but not in A: {0}", itemsInBNotInA.Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y));
                Console.WriteLine("A and B share the same elements? {0}", listsHaveAllElementsInCommon);
                Console.WriteLine("A and B are sequence-equal? {0}", listAreSequenceEqal);
                Console.Read();
            }
        }
    }
