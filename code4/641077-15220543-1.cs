    using System;
    using System.Diagnostics;
    static class Program
    {
        static void Main()
        {
            var ar = new int[500000000];
    
            for (int j = 0; j < 20; j++)
            {
                var sw = Stopwatch.StartNew();
                var length = ar.Length;
                for (var i = 0; i < length; i++)
                {
                    if (ar[i] == 0) ;
                }
    
                sw.Stop();
                long hoisted = sw.ElapsedMilliseconds;
    
                sw = Stopwatch.StartNew();
                for (var i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == 0) ;
                }
                sw.Stop();
                long direct = sw.ElapsedMilliseconds;
    
                Console.WriteLine("{0}: {1}ms vs {2}ms", j, hoisted, direct);
            }
        }
    }
