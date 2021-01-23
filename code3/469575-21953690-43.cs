    using System;
    using Syroot.Windows.IO;
    
    class Program
    {
        static void Main(string[] args)
        {
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            Console.WriteLine("Downloads folder path: " + downloadsPath);
            Console.ReadLine();
        }
    }
