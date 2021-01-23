    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                int size = 10000000;
                int count = 10;
                bool[] data = new bool[size];
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    AnySet1(data);
                Console.WriteLine(sw.Elapsed);
                sw.Restart();
                for (int i = 0; i < count; ++i)
                    AnySet2(data);
                Console.WriteLine(sw.Elapsed);
                sw.Restart();
                for (int i = 0; i < count; ++i)
                    AnySet3(data);
                Console.WriteLine(sw.Elapsed);
            }
            static bool AnySet1(bool[] data)
            {
                return data.Any(b => b);
            }
            static bool AnySet2(IEnumerable<bool> data)
            {
                return data.Any(b => b);
            }
            static bool AnySet3(bool[] data)
            {
                for (int i = 0; i < data.Length; ++i)
                    if (data[i])
                        return true;
                return false;
            }
        }
    }
