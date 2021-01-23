    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            const int MIN_LENGTH = 2;
            const int MAX_LENGTH = 3;
            static IList<string> vals;
    
            static void go(string cur)
            {
                if (cur.Length > MAX_LENGTH)
                {
                    return;
                }
                if (cur.Length >= MIN_LENGTH && cur.Length <= MAX_LENGTH)
                {
                    Console.WriteLine(cur);
                }
    
                foreach (string t in vals)
                {
                    cur += t;
                    go(cur);
                    cur = cur.Substring(0, cur.Length - 1);
                }
            }
            static int Main(string[] args)
            {
                vals = new List<string>();
                vals.Add("a");
                vals.Add("b");
                vals.Add("c");
    
                go("");
                return 0;
            }
        }
    }
