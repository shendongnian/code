            string source = @"d:\test";
            string dest = @"d:\move\";
            DirectoryInfo dirInfo = new DirectoryInfo(dest);
            if (dirInfo.Exists == false)
                Directory.CreateDirectory(dest);
            DirectoryInfo dir = new DirectoryInfo(source);
            DirectoryInfo[] dirs = dir.GetDirectories();
            string[] files = Directory.GetFiles(source);
            Int32 i = dirs.Count() + files.Count();
            //   for progress bar
            foreach (string file in files)
            {
                try
                {
                    string name = Path.GetFileName(file);
                    string destFile = Path.Combine(dest, name);
                    // skip some file
                    if (name != "file") File.Move(file, destFile);
                }
                catch
                {
                }
            }
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(dest, subdir.Name);
                if (!Directory.Exists(temppath))
                    try
                    {
                        Directory.Move(subdir.FullName, temppath);
                    }
                    catch
                    {
                    }
            }
