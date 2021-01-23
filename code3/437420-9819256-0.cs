    using System;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var s = "This is a simple string";
                var dic = Enumerable.Range(4, s.Length-3)
                                    .Select((m, i) => new { Key = i, Value = s.Substring(0, m) })
                                    .ToDictionary(a=>a.Key,a=>a.Value);
            }
        }
    }
