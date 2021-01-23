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
            // ... Has two parameters; return comparison of Item1 on each.
            list.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
