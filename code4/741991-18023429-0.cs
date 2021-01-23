    using System;
    using System.IO;
    
    namespace SQLiteEntityMigrator
    {
        class Program
        {
            static void Main()
            {
                string pathToDirectory = @"C:\Files";
                System.IO.DirectoryInfo diDir = new DirectoryInfo(pathToDirectory);
                System.IO.FileInfo[] files = diDir.GetFiles();
    
                foreach (FileInfo lfileInfo in files)
                {
                    // Work with files
                    Console.WriteLine(lfileInfo.Name);
                }
            }
        }
    }
