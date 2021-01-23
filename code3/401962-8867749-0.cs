    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var url = "http://stackoverflow.com/questions/8867710/is-string-equalsstring1-substring0-x-string2-better-than-string1-startswit";
                var count = 10000000;
                var http = false;
    
                Stopwatch sw = Stopwatch.StartNew();
    
                for (int i = 0; i < count; i++)
                {
                    http = url.StartsWith("http:", StringComparison.OrdinalIgnoreCase);
                }
    
                sw.Stop();
    
                Console.WriteLine("StartsWith: {0} ms", sw.ElapsedMilliseconds);
    
                sw.Restart();
    
                for (int i = 0; i < count; i++)
                {
                    http = string.Equals(url.Substring(0, 5), "http:", StringComparison.OrdinalIgnoreCase);
                }
    
                sw.Stop();
    
                Console.WriteLine("Equals: {0} ms", sw.ElapsedMilliseconds);
    
                Console.ReadLine();
            }
        }
    }
