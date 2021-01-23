    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void TestMs()
            {
                var s = new SortedSet<int>();
                int n = 100000;
                var rand = new Random(1000000007);
                int sum = 0;
                for (int i = 0; i < n; ++i)
                {
                    s.Add(rand.Next());
                    if (rand.Next() % 2 == 0)
                    {
                        int l = rand.Next(int.MaxValue / 2 - 10);
                        int r = l + rand.Next(int.MaxValue / 2 - 10);
                        var t = s.GetViewBetween(l, r);
                        sum += t.Min;
                    }
                }
            }
    
            static void TestMono()
            {
                var s = new MonoSortedSet<int>();
                int n = 100000;
                var rand = new Random(1000000007);
                int sum = 0;
                for (int i = 0; i < n; ++i)
                {
                    s.Add(rand.Next());
                    if (rand.Next() % 2 == 0)
                    {
                        int l = rand.Next(int.MaxValue / 2 - 10);
                        int r = l + rand.Next(int.MaxValue / 2 - 10);
                        var t = s.GetViewBetween(l, r);
                        sum += t.Min;
                    }
                }
            }
    
            static void Main(string[] args)
            {
                Stopwatch watch = new Stopwatch();
    
                watch.Start();
                TestMs();
                watch.Stop();
    
                Console.WriteLine("ms version time:{0}", watch.ElapsedMilliseconds);
                watch.Reset();
    
                watch.Start();
                TestMono();
                Console.WriteLine("mono version time:{0}", watch.ElapsedMilliseconds);
    
                Console.ReadLine();
            }
        }
    }
