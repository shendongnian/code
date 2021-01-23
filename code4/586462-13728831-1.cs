    static void WalkDirectoryTree(System.IO.DirectoryInfo root)
    {
        foreach(var subDirectory in root.GetDirectories(
            "*.*", 
            SearchOption.AllDirectories))
        {
            log.Add(subDirectory.ToString());
        }
    }
