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
                List<bool> data = new List<bool>(size);
                for (int i = 0; i < size; ++i)
                    data.Add(false);
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
                sw.Restart();
                for (int i = 0; i < count; ++i)
                    AnySet4(data);
                Console.WriteLine(sw.Elapsed);
            }
            static bool AnySet1(List<bool> data)
            {
                return data.Any(b => b);
            }
            static bool AnySet2(IEnumerable<bool> data)
            {
                return data.Any(b => b);
            }
            static bool AnySet3(List<bool> data)
            {
                for (int i = 0; i < data.Count; ++i)
                    if (data[i])
                        return true;
                return false;
            }
            static bool AnySet4(List<bool> data)
            {
                return data.Contains(true);
            }
        }
    }
