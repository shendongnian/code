    using System;
    using System.IO;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            long size = Directory
                .EnumerateFiles(@"c:\work", "d*")
                .Select(x => new FileInfo(x))
                .Sum(x => x.Length);
            Console.WriteLine(@"The size of files in c:\work\d* is {0} bytes", size);
        }
    }
