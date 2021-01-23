    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace ConsoleApplication58
    {
        internal class Program
        {
            private class A
            {
    
            }
    
            private static bool F<T>(T a, T b) where T : class
            {
                return a == b;
            }
    
            private static bool F2(A a, A b)
            {
                return a == b;
            }
    
            private static void Main()
            {
                const int rounds = 100, n = 100000;
                var a = new A();
                var fList = new List<TimeSpan>();
                var f2List = new List<TimeSpan>();
                for (int i = 0; i < rounds; i++)
                {
                    //test generic
                    GCClear();
                    bool res;
                    var sw = new Stopwatch();
                    sw.Start();
                    for (int j = 0; j < n; j++)
                    {
                        res = F(a, a);
                    }
                    sw.Stop();
                    fList.Add(sw.Elapsed);
    
                    //test not-generic
                    GCClear();
                    bool res2;
                    var sw2 = new Stopwatch();
                    sw2.Start();
                    for (int j = 0; j < n; j++)
                    {
                        res = F2(a, a);
                    }
                    sw2.Stop();
                    f2List.Add(sw2.Elapsed);
                }
                Console.WriteLine("Elapsed for F = {0} \t ticks = {1}", fList.Average(ts => ts.TotalMilliseconds),
                                  fList.Average(ts => ts.Ticks));
                Console.WriteLine("Elapsed for F2 = {0} \t ticks = {1}", f2List.Average(ts => ts.TotalMilliseconds),
                      f2List.Average(ts => ts.Ticks));
                Console.ReadKey();
            }
    
            private static void GCClear()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
    }
