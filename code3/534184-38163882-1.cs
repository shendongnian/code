    using System;
    using System.IO;
    
    // ...
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            FileRenamer(@"D:\Test\C++ Beginner's Guide", "Module", "PDF");
            Console.ForegroundColor = ConsoleColor.Gray;
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
                int searchstart = filename.IndexOf(search);
                if (searchstart == -1)
                    continue;
                int searchend = filename.Substring(0, searchstart).Length + (search.Length);
                string partone = filename.Substring(0, searchstart);
                string partthree = filename.Substring(searchend);
                string replaced = partone + replace + partthree;
                int folderindex = filepath.LastIndexOf('\\');
                string destination = filepath.Substring(0, folderindex) + replaced;
                File.Move(filepath, destination);
            }
            string[] directories = Directory.GetDirectories(source);
            foreach (string directory in directories)
            {
                int subdirindex = directory.LastIndexOf('\\');
                string subdirname = directory.Substring(subdirindex);
                string structure = source + subdirname;
                FileRenamer(structure, search, replace);
            }
        }
