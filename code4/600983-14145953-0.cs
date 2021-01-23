    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                File.Copy("c:\\myFile.ext", "c:\\temp\\myFile2.ext");
            }
        }
    }
