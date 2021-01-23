    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    public class Test
    {
        static void Main()
        {
            List<string> list = new List<string>();
            string longString = new string('x', 1000) + " ";
            for (int i = 0; i < 1000000; i++)
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
            GC.Collect();
        
            sw = Stopwatch.StartNew();
            List<string> listResult = new List<string>();
            int countList = list.Count;
            for (int i = 0; i < countList; i++)
            {
                string item = list[i];
                if (!string.IsNullOrWhiteSpace(item))
                {
                    listResult.Add(item);
                }
            }
            sw.Stop();
            Console.WriteLine("New list: {0}", sw.ElapsedMilliseconds);
            GC.Collect();
            // This has to be last, as it modifies in-place 
            sw = Stopwatch.StartNew();
            list.RemoveAll(r => string.IsNullOrWhiteSpace(r));
            sw.Stop();
            Console.WriteLine("List.RemoveAll: {0}", sw.ElapsedMilliseconds);
        }        
    }
