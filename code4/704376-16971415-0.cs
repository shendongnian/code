    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            void Run()
            {
                int size = 10000000;
                bool[] array = new bool[size];
                for (int i = 0; i < size - 1; ++i)
                    array[i] = true;
                int count = 100;
                time(() => UnsafeCountSetFlags(array), "Unsafe", count);
                time(() => SafeCountSetFlags(array),   "Safe",   count);
                time(() => LinqCountSetFlags(array),   "Linq",   count);
            }
            void time(Action action, string title, int count)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    action();
                Console.WriteLine(title + " took " + sw.Elapsed);
            }
            int UnsafeCountSetFlags(bool[] array)
            {
                unsafe
                {
                    fixed (bool* parray = array)
                    {
                        int total = 0;
                        for (bool* p = parray, end = parray + array.Length; p != end; ++p)
                            if (*p)
                                ++total;
                        return total;
                    }
                }
            }
            int SafeCountSetFlags(bool[] array)
            {
                int total = 0;
                foreach (bool flag in array)
                    if (flag)
                        ++total;
                return total;
            }
            int LinqCountSetFlags(bool[] array)
            {
                return array.Count(flag => flag);
            }
            static void Main()
            {
                new Program().Run();
            }
        }
    }
                                                                              
