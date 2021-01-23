    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace ExampleApplication {
        class Program {
            static void Main(string[] args) {
                FileInfo fi = new FileInfo("C:\\TEST.TXT");
                fi.Create();
                fi.Close();
                Console.WriteLine("File exists: {0}", fi.Exists);
            }
        }
    }
