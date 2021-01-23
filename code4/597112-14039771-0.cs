    using System;
    using System.IO;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            var lines = File.ReadLines("test.txt");
            var query = from x in lines
                        from y in lines
                        select x + "/" + y;
            foreach (var line in query)
            {
                Console.WriteLine(line);
            }
        }
    }
