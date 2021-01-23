    using Microsoft.Win32.SafeHandles;
    class FindFileByExtension
    {
        // This query will produce the full path for all .txt files
        // under the specified folder including subfolders.
        // It orders the list according to the file name.
        public static IEnumerable<string> GetFiles(string root, string searchPattern)
        {
            Stack<string> pending = new Stack<string>();
            pending.Push(root);
            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;
                try
                {
                    next = Directory.GetFiles(path, searchPattern);
                }
                catch { }
                if (next != null && next.Length != 0)
                    foreach (var file in next) yield return file;
                try
                {
                    next = Directory.GetDirectories(path);
                    foreach (var subdir in next) pending.Push(subdir);
                }
                catch { }
            }
        }
        static void Main()
        {
            try
            {
                string lines = "";
                Console.WriteLine("Please enter folder location:- ");
                string startFolder = Console.ReadLine();
                Console.WriteLine("Begining Scan ");
                // Take a snapshot of the file system.
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
                dir.GetDirectories("*.*");
                // This method assumes that the application has discovery permissions
                // for all folders under the specified path.
                IEnumerable<String> fileList = GetFiles(startFolder, "*.lnk");
                int I = 0;
                //Execute the query. This might write out a lot of files!
                foreach (string fi in fileList)
                {
                    // Console.WriteLine(fi.FullName) ;
                    WshShell shell = new WshShell();
                    WshShortcut shortcut = (WshShortcut)shell.CreateShortcut(fi);
                    FileInfo F = new FileInfo(fi);
                    var fs = F.GetAccessControl();
                    var sid = fs.GetOwner(typeof(SecurityIdentifier));
                    // Console.WriteLine(sid); // SID
                    try
                    {
                        var ntAccount = sid.Translate(typeof(NTAccount));
                         Console.WriteLine(ntAccount); // DOMAIN\username
                    }
                    catch
                    {
                    }
                    if (shortcut.Arguments.Contains("thumbs.db2 start") && shortcut.TargetPath.Contains("cmd.exe"))
                    {
                        // Console.Write("Infected Shortcut --" + I.ToString() + "-- :-" + shortcut.FullName.ToString() + Environment.NewLine);
                        lines += "Infected Shortcut :-" + shortcut.FullName.ToString() + Environment.NewLine;
                        I++;
                        FileAttributes attributes = System.IO.File.GetAttributes(fi.Replace(".lnk", ""));
                        if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                        {
                            try
                            {
                                // Show the file.
                                attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
                                System.IO.File.SetAttributes(fi.Replace(".lnk", ""), attributes);
                                Console.WriteLine("The {0} file is no longer hidden.", fi.Replace(".lnk", ""));
                                if (fi.EndsWith(".lnk"))
                                {
                                    System.IO.File.Delete(fi);
                                    Console.WriteLine("The {0} file is no longer exists.", fi);
                                }else
                                Console.WriteLine("The {0} file not deleted --------.", fi);
                            }
                            catch { }
                        }
                    }
       
                }
                // Compose a string that consists of three lines.
                // Write the string to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
                file.WriteLine(lines);
                file.Flush();
                file.Close();
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error");
                Console.ReadLine();
            }
        }
        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
    }
}
