    using System;
    using System.IO;
    using System.IO.Compression;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var zipToOpen = 
                    new FileStream(@"c:\tmp\release.zip", FileMode.Open))
                {
                    using (var archive = 
                         new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                    {
                        var readmeEntry = archive.CreateEntry("Readme.txt");
                        using (var writer = new StreamWriter(readmeEntry.Open()))
                        {
                                writer.WriteLine("Information about this package.");
                                writer.WriteLine("========================");
                        }
                    }
                }
            }
        }
    }
