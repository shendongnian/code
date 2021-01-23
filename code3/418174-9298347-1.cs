    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    public class Test
    {
        static void Main()
        {
            List<string> list = new List<string>();
            string longString = new string('x', 10000) + " ";
            for (int i = 0; i < 100000; i++)
            {
                list.Add(i % 100 == 0 ? "" : longString);
            }
            
            Stopwatch sw = Stopwatch.StartNew();
            list.Where(r=> !string.IsNullOrEmpty(r.Trim())).ToList();
            sw.Stop();
            Console.WriteLine("IsNullOrEmpty(Trim): {0}", sw.ElapsedMilliseconds);
            
            GC.Collect();
            
            sw = Stopwatch.StartNew();
            list.Where(r=> !string.IsNullOrWhiteSpace(r)).ToList();
            sw.Stop();
            Console.WriteLine("IsNullOrWhitespace: {0}", sw.ElapsedMilliseconds);
        }        
    }
