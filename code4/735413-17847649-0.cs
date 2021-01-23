    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var b = new BuildFileList();
                var sw = new Stopwatch();
                sw.Start();
                var files = b.GetFiles();
                sw.Stop();
                Console.WriteLine("Found {0} files in {1} seconds", files.Count, sw.Elapsed.TotalSeconds);
                Console.ReadLine();
            }
        }
    
        public class BuildFileList
        {
            public List<FileInfo> GetFiles()
            {
                var di = new DirectoryInfo(@"C:\");
                var directories = di.GetDirectories();
                var files = new List<FileInfo>();
                foreach (var directoryInfo in directories)
                {
                    try
                    {
                        GetFilesFromDirectory(directoryInfo.FullName, files);
                    }
                    catch (Exception)
                    {
                    }
                }
                return files;
            }
    
    
            private void GetFilesFromDirectory(string directory, List<FileInfo> files)
            {
                var di = new DirectoryInfo(directory);
                var fs = di.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                files.AddRange(fs);
                var directories = di.GetDirectories();
                foreach (var directoryInfo in directories)
                {
                    try
                    {
                        GetFilesFromDirectory(directoryInfo.FullName, files);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
    
        }
    }
