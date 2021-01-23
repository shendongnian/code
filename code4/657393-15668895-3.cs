    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            var lines = File.ReadAllLines(@"\Users\Jon\Test\Test.cs");
            Console.WriteLine(lines.Length);
        }
    }
