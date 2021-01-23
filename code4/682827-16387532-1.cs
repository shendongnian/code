    using System;
    using System.Diagnostics;
    namespace Demo
    {
        internal class Program
        {
            private static void Main()
            {
                new Program().test();
            }
            private void test()
            {
                Stopwatch sw = new Stopwatch();
                int count = 10000000;
                for (int i = 0; i < 5; ++i)
                {
                    sw.Restart();
                    Loop(count);
                    Console.WriteLine(sw.Elapsed + " Loop");
                    sw.Restart();
                    Loop2(count);
                    Console.WriteLine(sw.Elapsed + " Loop2");
                    Console.WriteLine();
                }
            }
            public long Loop(long testSize)
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
            public long Loop2(long testSize)
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
