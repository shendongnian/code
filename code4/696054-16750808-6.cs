    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Threading;
    namespace Demo
    {
        class Rpm
        {
            private Stopwatch stopWatch = new Stopwatch();
            private int lastRPM = -1;
            // RPM will be -1 until we have received two "1"s       
            public int CalcolaRPM(string giriRicevuti)
            {
                if (giriRicevuti == "1")
                {
                    if (stopWatch.IsRunning)
                        lastRPM = (int) Math.Round(60000.0/((int) stopWatch.ElapsedMilliseconds));
                    stopWatch.Restart();
                }
                return lastRPM;
            }
        }
    
        class Program
        {
            void run()
            {
                test(900);
                test(1000);
                test(1100);
                test(500);
                test(200);
            }
            void test(int interval)
            {
                Rpm rpm = new Rpm();
                for (int i = 0; i < 10; ++i)
                {
                    Thread.Sleep(interval);
                    rpm.CalcolaRPM("0");
                    rpm.CalcolaRPM("1").Print();
                    rpm.CalcolaRPM("2");
                }
            }
            static void Main()
            {
                new Program().run();
            }
        }
        static class DemoUtil
        {
            public static void Print(this object self)
            {
                Console.WriteLine(self);
            }
            public static void Print(this string self)
            {
                Console.WriteLine(self);
            }
            public static void Print<T>(this IEnumerable<T> self)
            {
                foreach (var item in self) Console.WriteLine(item);
            }
        }
    }
                                                                              
