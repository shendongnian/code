    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections.Generic;
    namespace Demo
    {
        public static class Program
        {
            [STAThread]
            public static void Main(string[] args)
            {
                var dict = new Dictionary<string, List<string>>();
                var strings = new List<string>();
                int n1 = 10000;
                int n2 = 50000;
                for (int i = 0; i < n1; ++i)
                    strings.Add("TEST");
                for (int i = 0; i < n2; ++i)
                    dict.Add(i.ToString(), strings);
                for (int i = 0; i < 4; ++i)
                {
                    var sw = Stopwatch.StartNew();
                    dict.Count(kvp => kvp.Value.Contains("specific value"));
                    Console.WriteLine("Contains() took: " + sw.Elapsed);
                    sw.Restart();
                    dict.Values.SelectMany(v => v).Count(v => v == "specific value");
                    Console.WriteLine("SelectMany() took: " + sw.Elapsed);
                }
            }
        }
    }
