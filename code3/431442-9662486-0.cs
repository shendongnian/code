    use the following code
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ExampleApplication {
        class Program {
            static void Main(string[] args) {
             if(!File.Exists("C:\\TEST.TXT"))
             {
                 GC.Collect();
                 GC.WaitForPendingFinalizers();
                 fi.Create();
                 fi.Close();
                 Console.WriteLine("File exists: {0}", fi.Exists);
            }
          }
        }
    }
