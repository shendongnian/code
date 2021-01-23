    using System;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                FileSystemWatcher fsw = new FileSystemWatcher();
                fsw.Path = @"D:\test";
                fsw.Deleted += new FileSystemEventHandler(ReportChange); 
                fsw.Created += new FileSystemEventHandler(ReportChange);
                fsw.EnableRaisingEvents = true;
 
                Console.In.ReadLine();
            }
  
            private static void ReportChange(object source, FileSystemEventArgs e)
            {
                // Specify what is done when a file is created or deleted.
                Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            }
        }
    }
