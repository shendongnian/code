    public static TotallyNotRecursiveAndCreateDirs(string root, string newRoot)
        {
            DirectoryInfo rootDir = new DirectoryInfo(Path.GetPathRoot(root)); 
            DirectoryInfo[] dirs = rootDir.GetDirectories("*", SearchOption.AllDirectories);
            foreach(DirectoryInfo dir in dirs)
            {
                Directory.CreateDirectory(dir.FullName.Replace(root, newRoot));
                FileInfo[] files = dir.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                foreach(FileInfo file in files)
                {
                    File.Create(file.FullName.Replace(root, newRoot));
                }
            }
        }
