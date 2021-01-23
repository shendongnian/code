    using System;
    using System.IO;
    using System.Linq;
    
    namespace getfilesFilter
    {
        class Program
        {
            static void Main(string[] args)
            {
                var files = Directory.GetFiles(@"C:\temp", "*.bin").Select(p => Path.GetFileName(p)).Where(p => p.StartsWith("LOG"));
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
                Console.ReadLine();
            }
        }
    }
