    namespace ConsoleApplication1
    {
        using System;
        using System.Collections.Generic;
        using System.IO;
    
        class Program
        {
            public static IList<DirectoryInfo> dirs;
    
            static void Main(string[] args)
            {
                dirs = new List<DirectoryInfo>();
    
                var dir = new DirectoryInfo(@"c:\tmp");
    
                GetDirs(dir);
                Console.WriteLine(dirs.Count);
            }
    
            public static void GetDirs(DirectoryInfo root)
            {
                foreach (var directoryInfo in root.GetDirectories())
                {
                    dirs.Add(directoryInfo);
                    GetDirs(directoryInfo);
                }
            }
        }
    }
