    using System;
    using System.Diagnostics;
    using System.Threading;
    
    namespace TestProject
    {
        class Program
        {
            private string str = "xxxxxxxxxxxxxxx";
            public string Str
            {
                get
                {
                    return str;
                }
                set
                {
                    if (str != value)
                    {
                        str = value;
                    }
                    // Do some work which take 1 second
                    Thread.Sleep(1000);
                }
            }
    
            static void Main(string[] args)
            {
                var p = new Program();
    
                var iterations = 10;
    
                var sw = new Stopwatch();
                for (int i = 0; i < iterations; i++)
                {
                    if (i == 1) sw.Start();
                    if (p.Str == null)
                    {
                        p.Str = "yyyy";
                    }
                }
                sw.Stop();
                var first = sw.Elapsed;
    
                sw.Reset();
                for (int i = 0; i < iterations; i++)
                {
                    if (i == 1) sw.Start();
                    p.Str = p.Str ?? "yyyy";
                }
                sw.Stop();
                var second = sw.Elapsed;
    
                Console.WriteLine(first);
                Console.WriteLine(second);
    
                Console.Write("Ratio: ");
                Console.WriteLine(second.TotalMilliseconds / first.TotalMilliseconds);
                Console.ReadLine();
            }
    
        }
    }
