    using System;
    using System.Collections.Generic;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            string[] lines = { "first", "second", "third" };
            
            for (int i = 0; i < 10; i++)
            {
                File.WriteAllLines("test.txt", lines);
                
                lines = File.ReadAllLines("test.txt");
                Console.WriteLine("Number of lines read: {0}", lines.Length);
            }
        }
    }
