    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                string[] classes = {"X", "Y", "Z"};
                foreach (var combination in PowerSet(classes))
                {
                    foreach (var item in combination)
                    {
                        Console.Write(item + ", ");
                    }
                    Console.WriteLine("");
                }
            }
            public static IEnumerable<IEnumerable<T>> PowerSet<T>(T[] sequence)
            {
                return from m in Enumerable.Range(0, 1 << sequence.Length)
                       select
                           from i in Enumerable.Range(0, sequence.Length)
                           where (m & (1 << i)) != 0
                           select sequence[i];
            }
        }
    }
