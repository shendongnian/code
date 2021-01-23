    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<List<int>> lists = new List<List<int>>();
    
                lists.Add(new List<int> { 1, 2, 3 });
                lists.Add(new List<int> { 1, 2, 3 });
                lists.Add(new List<int> { 9, 10, 11 });
                lists.Add(new List<int> { 1, 2, 3 });
    
                var distinct = lists.Select(x => new HashSet<int>(x))
                        .Distinct(HashSet<int>.CreateSetComparer());
    
                foreach (var list in distinct)
                {
                    foreach (var v in list)
                    {
                        Console.Write(v + " ");
                    }
    
                    Console.WriteLine();
                }
            }
        }
    }
