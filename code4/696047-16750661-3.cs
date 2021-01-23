    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            List<Tuple<string, int>> list = new List<Tuple<string, int>>();
            list.Add(new Tuple<string, int>("Bob",80 ));
            list.Add(new Tuple<string, int>("Alice", 95));
            list.Add(new Tuple<string, int>("Roger", 70));
            list.Add(new Tuple<string, int>("Oscar", 85));
            // Use Sort method with Comparison delegate.
            // ... Has two parameters; return comparison of Item2 on each.
            list.Sort((a, b) => a.Item2.CompareTo(b.Item2));
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
