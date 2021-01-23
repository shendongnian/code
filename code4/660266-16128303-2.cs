    using System;
    using System.IO;
    using IWshRuntimeLibrary;  //COM object -Windows Script Host Object Model
    
    namespace csCon
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Folder is set to Desktop 
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var di = new DirectoryInfo(dir);
                FileInfo[] fis = di.GetFiles();
                if (fis.Length > 0)
                {
                    foreach (FileInfo fi in fis)
                    {
                        if (fi.FullName.EndsWith("lnk"))
                        {
                            IWshShell shell = new WshShell();
                            var lnk = shell.CreateShortcut(fi.FullName) as IWshShortcut;
                            if (lnk != null)
                            {
                                Console.WriteLine("Link name: {0}", lnk.FullName);
                                Console.WriteLine("link target: {0}", lnk.TargetPath);
                                Console.WriteLine("link working: {0}", lnk.WorkingDirectory);
                                Console.WriteLine("description: {0}", lnk.Description);
                            }
                           
                        }
                    }
                }
            }
        }
    }
