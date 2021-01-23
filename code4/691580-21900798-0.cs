    using System;
    using System.Diagnostics;
    using System.Threading;
    
    namespace HighFrequency
    {
        class Program
        {
            static void Main(string[] args)
            {
                var count = 0;
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                while(count <= 1000)
                {
                    Thread.Sleep(1);
                    count++;
                }
                stopwatch.Stop();
                Console.WriteLine("C# .NET 4.0 avg. {0}", stopwatch.Elapsed.TotalSeconds / count);
            }
        }
    }
