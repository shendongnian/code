    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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
            }
            void time(Action action, string title, int count)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    action();
                Console.WriteLine(title + " took " + sw.Elapsed);
            }
            List<int> UnsafeCountSetFlags(bool[] array)
            {
                unsafe
                {
                    fixed (bool* parray = array)
                    {
                        List<int> result = new List<int>();
                        for (bool* p = parray, end = parray + array.Length; p != end; ++p)
                            if (*p)
                                result.Add((int)(p-parray));
                        return result;
                    }
                }
            }
            List<int> SafeCountSetFlags(bool[] array)
            {
                List<int> result = new List<int>();
                for (int i = 0; i < array.Length; ++i)
                    if (array[i])
                        result.Add(i);
                return result;
            }
            static void Main()
            {
                new Program().Run();
            }
        }
    }
                                                                              
