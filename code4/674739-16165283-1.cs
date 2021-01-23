    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                for (int i = 0; i < 100; ++i)
                {
                    var t1 = DateTime.UtcNow;
                    Thread.Sleep(0);
                    var t2 = DateTime.UtcNow;
                    Console.WriteLine("UtcNow elapsed = " + (t2-t1).Ticks);
                }
                for (int i = 0; i < 100; ++i)
                {
                    long q1, q2;
                    QueryPerformanceCounter(out q1);
                    Thread.Sleep(0);
                    QueryPerformanceCounter(out q2);
                    Console.WriteLine("QPC elapsed = " + (q2-q1));
                }
            }
            [DllImport("kernel32.dll", SetLastError=true)]
            static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        }
    }
