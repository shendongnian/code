    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text; 
    using Ionic.Zip;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string myZip = @"C:\temp\test.zip";
                string myOtherZip = @"C:\temp\anotherZip.zip";
                string outputDirectory = @"C:\ZipTest";
                using (ZipFile zip = ZipFile.Read(myZip))
                {
                    zip.ExtractAll(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
                using (ZipFile zipDest = ZipFile.Read(myOtherZip))
                {
                    //zipDest.AddFiles(System.IO.Directory.EnumerateFiles(outputDirectory)); //This will add them as a directory
                    zipDest.AddFiles((System.IO.Directory.EnumerateFiles(outputDirectory)),false,""); //This will add the files to the root
                    zipDest.Save();
                }
            }
        }
    }
