    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestSpeed
    {
        class Program
        {
            private static double a;
            private static double b;
            private static double c = 0.34;
            private static double d = 0.15;
            private static double e = 0.25;
            private static double f = 0.03;
            private static double g = 8;
    
            static void Main(string[] args)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Parallel.For(0, 1000000000, (p) =>
                {
                    double e = a;
                    a = 1;
                    double f = b;
                    b = 1;
                    if (true)
                    {
                        double h = 1.83;
    
                        double j = Math.Ceiling(h / d);
                        if (j <= c)
                        {
                            c = Math.Ceiling(h / d + e);
                        }
                        else if (j > c)
                        {
                            c = Math.Ceiling(h / d - e);
                        }
                        if (c <= -0.5)
                        {
                            a = a - f * c;
                        }
    
                        double k = Math.Floor(h / d);
                        if (k <= g)
                        {
                            g = Math.Floor(h / d + e);
                        }
                        else if (k > g)
                        {
                            g = Math.Floor(h / d - e);
                        }
                        if (g > 0.5)
                        {
                            b = b + f * g;
                        }
                    }
    
                    bool result = (Math.Abs(e - a) > 0) ||
                                  (Math.Abs(f - b) > 0);
                });
                sw.Stop();
                long time = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
                Console.WriteLine(time);
                Console.WriteLine(sw.Elapsed.ToString());
                Console.Read();
            }
        }
    }
