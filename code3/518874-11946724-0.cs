            string topfolder = @"c:\temp\utils\";
            string filename = "project.zip";
            foreach (string dir in Directory.GetDirectories(topfolder, "Project-*", SearchOption.TopDirectoryOnly))
            {
                IEnumerable<string> files = Directory.GetFiles(dir, "*.*", SearchOption.TopDirectoryOnly).Select(f => Path.GetFileName(f));
                if (files.Count() > 1)
                #region if directory contains extra (unexpected) files
                {
                    Console.WriteLine(string.Format("Directory {0} contains {1} files", dir, files.Count()));
                }
                #endregion if directory contains extra (unexpected) files
                if (!files.Contains(filename))
                {
                    Console.WriteLine(string.Format("File is not found in {0}", dir));
                    #region Searching for the file in depth
                    files = Directory.GetFiles(dir, filename, SearchOption.AllDirectories);
                    if (files.Count() > 0)
                    {
                        Console.WriteLine("The file has been found too deep:");
                        foreach (string s in files)
                            Console.WriteLine(s);
                    }
                    #endregion Searching for the file in depth
                }
                #region Searching for extra (unexpected) subdirectories
                int dircount = Directory.GetDirectories(dir, "*.*", SearchOption.TopDirectoryOnly).Length;
                if (dircount > 0)
                    Console.WriteLine(string.Format("Directory {0} contains {1} subdirectories", dir, dircount));
                #endregion Searching for extra (unexpected) subdirectories
            }
            Console.ReadLine();
