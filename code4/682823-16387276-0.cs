    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Stopwatch sw = new Stopwatch();
                while (true)
                {
                    sw.Start();
                    Loop(5000000);
                    sw.Stop();
                    Console.WriteLine("Loop: {0}ms", sw.ElapsedMilliseconds);
                    sw.Reset();
    
                    sw.Start();
                    Loop2(5000000);
                    sw.Stop();
                    Console.WriteLine("Loop2: {0}ms", sw.ElapsedMilliseconds);
                    sw.Reset();
    
                    Console.ReadLine();
                }
            }
    
            static long Loop(long testSize)
            {
                long ret = 0;
                for (long i = 0; i < testSize; i++)
                {
                    long p = 0;
                    for (int j = 0; j < 1000; j++)
                    {
                        p++;
                    }
                    ret += p;
                }
                return ret;
            }
    
            static long Loop2(long testSize)
            {
                long ret = 0;
                for (long i = 0; i < testSize; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ret++;
                    }
                }
                return ret;
            }
        }
    
    }
