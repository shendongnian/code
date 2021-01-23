    using System;
    using System.Linq;
    
    using Scripting;
    using System.Diagnostics;
    using System.IO;
    
    namespace akTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Stopwatch watch = new Stopwatch();
    
                watch.Start();
                testFileInfo(@"c:\");
                watch.Stop();
                o("FileInfo traversal needed " + (watch.ElapsedMilliseconds/1000.0).ToString("#.##") + "s");
    
                watch.Start();
                testFSO(@"c:\");
                watch.Stop();
                o("FileInfo traversal needed " + (watch.ElapsedMilliseconds / 1000.0).ToString("#.##") + "s");
    
                o("");
                o("Ciao!");
            }
    
            static void o(string s)
            {
                Console.WriteLine(s);
            }
    
            static void testFileInfo(string dir)
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                long fileCount = 0;
                long dirCount = 0;
                long calls = 0;
    
                o("Testing FileInfo");
    
                WalkDirectoryTree(di, ref fileCount, ref dirCount, ref calls);
    
                o("testFileInfo completed. Files: " + fileCount + " Directories: " + dirCount + " Calls: " + calls);
            }
    
            static void testFSO(string dir)
            {
                FileSystemObject fso = new FileSystemObject();
                Folder folder = fso.GetFolder(dir);
    
                long fileCount = 0;
                long dirCount = 0;
                long calls = 0;
    
                o("Testing FSO");
    
                WalkDirectoryTree(folder, ref fileCount, ref dirCount, ref calls);
    
                o("testFSO completed. Files: " + fileCount + " Directories: " + dirCount + " Calls: " + calls);
            }
    
            static void WalkDirectoryTree(DirectoryInfo root, ref long fileCount, ref long dirCount, ref long calls)
            {
                FileInfo[] files = null;
                DirectoryInfo[] subDirs = null;
    
                if (++calls % 10000 == 0)
                    o("" + calls);
    
                try
                {
                    files = root.GetFiles("*.*");
    
                    if (files != null)
                    {
                        fileCount += files.Count();
                        subDirs = root.GetDirectories();
                        dirCount += subDirs.Count();
    
                        foreach (DirectoryInfo dirInfo in subDirs)
                        {
                            WalkDirectoryTree(dirInfo, ref fileCount, ref dirCount, ref calls);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
    
    
            static void WalkDirectoryTree(Folder root, ref long fileCount, ref long dirCount, ref long calls)
            {
                Files files = null;
                Folders subDirs = null;
    
                if (++calls % 10000 == 0)
                    o("" + calls);
    
                try
                {
                    files = root.Files;
    
                    if (files != null)
                    {
                        fileCount += files.Count;
                        subDirs = root.SubFolders;
                        dirCount += subDirs.Count;
    
                        foreach (Folder fd in subDirs)
                        {
                            WalkDirectoryTree(fd, ref fileCount, ref dirCount, ref calls);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
