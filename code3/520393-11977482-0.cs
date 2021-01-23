    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    class Foo
    {
        public object Value { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            var list = new List<Foo>
            {
                new Foo { Value = "" },
                new Foo { Value = 10 },
                new Foo { Value = new object() },
                new Foo { Value = new MemoryStream() }
            };
            
            ShowCount<IDisposable>(list); // 1 (MemoryStream)
            ShowCount<IFormattable>(list); // 1 (Int32)
            ShowCount<IComparable>(list); // 1 (String, Int32)
        }
        
        static void ShowCount<T>(List<Foo> list)
        {
            var matches = list.Where(f => f.Value is T)
                              .ToList();
            Console.WriteLine("{0} matches for {1}", 
                              matches.Count, typeof(T));
        }
    }
