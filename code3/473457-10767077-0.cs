    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
        namespace WriteToTheHosts
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    Console.WriteLine(systemPath);
                    var path = Path.Combine(systemPath, @"drivers\etc\hosts");
                    using (var stream = new StreamWriter(path, true, Encoding.Default))
                    {
                        stream.WriteLine("#from .NET");
                    }
                    Console.ReadKey();
        
                }
            }
        }
