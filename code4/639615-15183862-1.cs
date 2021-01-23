    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    namespace testPath
    {
        class Program
        {
            static void Main(string[] args)
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "main.cpl");
                Console.WriteLine(File.Exists(path));
                Console.ReadLine();
            }
        }
    }
