        public static IEnumerable<string> FindAllFiles(string rootDir)
        {
            var pathsToSearch = new Queue<string>();
            
            pathsToSearch.Enqueue(rootDir);
            while (pathsToSearch.Count > 0)
            {
                var dir = pathsToSearch.Dequeue();
                var foundFiles = new List<string>();
                try
                {
                    foreach (var file in Directory.GetFiles(dir))
                        foundFiles.Add(file);
                    foreach (var subDir in Directory.GetDirectories(dir))
                    {
                        //comment this if want to follow symbolic link
                        //or follow them conditionally
                        if (IsSymbolic(subDir)) continue;
                        pathsToSearch.Enqueue(subDir);
                    }
                }
                catch (Exception) {//deal with exceptions here
                }
                foreach (var file in foundFiles) yield return file;
            } 
            
            
        }
        static private bool IsSymbolic(string path)
        {
            FileInfo pathInfo = new FileInfo(path);
            return pathInfo.Attributes.HasFlag(System.IO.FileAttributes.ReparsePoint);
        }
        static public void test()
        {
            string root = @"D:\root";
            foreach (var fn in FindAllFiles(root)
                .Where(x=>
                true    //filter condition here
                ))
            {
                Debug.WriteLine(fn);
            }
        }
