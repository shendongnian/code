    using System;
    using System.Diagnostics;
    using System.Linq;
    
    
    namespace PerformanceConsoleApp
    {
        public class LinqVsFor
        {
    
            private static void Main(string[] args)
            {
                string[] a = new string[1000000];
    
                for (int i = 0; i < a.Length; ++i)
                {
                    a[i] = "Won't be found";
                }
    
                string matchString = "Will be found";
    
                a[a.Length - 1] = "Will be found";
    
                const int COUNT = 100;
    
                var sw = Stopwatch.StartNew();
    
                Loop(a, matchString, COUNT, sw);
    
                First(a, matchString, COUNT, sw);
    
    
                Where(a, matchString, COUNT, sw);
    
                IndexOf(a, sw, matchString, COUNT);
    
                Console.ReadLine();
            }
    
            private static void Loop(string[] a, string matchString, int COUNT, Stopwatch sw)
            {
                int matchIndex = -1;
                for (int outer = 0; outer < COUNT; ++outer)
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i] == matchString)
                        {
                            matchIndex = i;
                            break;
                        }
                    }
                }
    
                sw.Stop();
                Console.WriteLine("Found via loop at index " + matchIndex + " in " + sw.Elapsed);
                
            }
    
            private static void IndexOf(string[] a, Stopwatch sw, string matchString, int COUNT)
            {
                int matchIndex = -1;
                sw.Restart();
                for (int outer = 0; outer < COUNT; ++outer)
                {
                    matchIndex = Array.IndexOf(a, matchString);
                }
                sw.Stop();
                Console.WriteLine("Found via IndexOf at index " + matchIndex + " in " + sw.Elapsed);
                
            }
    
            private static void First(string[] a, string matchString, int COUNT, Stopwatch sw)
            {
                sw.Restart();
                string str = "";
                for (int outer = 0; outer < COUNT; ++outer)
                {
                    str = a.First(t => t == matchString);
    
                }
                sw.Stop();
                Console.WriteLine("Found via linq First at index " + Array.IndexOf(a, str) + " in " + sw.Elapsed);
    
            }
    
            private static void Where(string[] a, string matchString, int COUNT, Stopwatch sw)
            {
                sw.Restart();
                string str = "";
                for (int outer = 0; outer < COUNT; ++outer)
                {
                    str = a.Where(t => t == matchString).First();
    
                }
                sw.Stop();
                Console.WriteLine("Found via linq Where at index " + Array.IndexOf(a, str) + " in " + sw.Elapsed);
    
            }
    
        }
    
    }
