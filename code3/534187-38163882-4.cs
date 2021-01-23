    using System;
    using System.IO;
    
    // ...
        static void Main(string[] args)
        {
            FileRenamer(@"D:\C++ Beginner's Guide", "Module", "PDF");
            Console.Write("Press any key to quit . . . ");
            Console.ReadKey(true);
        }
        static void FileRenamer(string source, string search, string replace)
        {
            string[] files = Directory.GetFiles(source);
            foreach (string filepath in files)
            {
                int fileindex = filepath.LastIndexOf('\\');
                string filename = filepath.Substring(fileindex);
                int startIndex = filename.IndexOf(search);
                if (startIndex == -1)
                    continue;
                int endIndex = startIndex + search.Length;
                string newName = filename.Substring(0, startIndex);
                newName += replace;
                newName += filename.Substring(endIndex);
                string fileAddress = filepath.Substring(0, fileindex);
                fileAddress += newName;
                File.Move(filepath, fileAddress);
            }
            string[] subdirectories = Directory.GetDirectories(source);
            foreach (string subdirectory in subdirectories)
                FileRenamer(subdirectory, search, replace);
        }
