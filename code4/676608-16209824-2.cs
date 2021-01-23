    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                int dummy = 0;
                int count = 1000000000;
                var array = new int[1] as ICollection<int>;
                var list = new List<int> {0};
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    dummy += array.Count;
                Console.WriteLine("Array elapsed = " + sw.Elapsed);
                dummy = 0;
                sw.Restart();
                for (int i = 0; i < count; ++i)
                    dummy += list.Count;
                Console.WriteLine("List elapsed = " + sw.Elapsed);
            }
        }
    }
