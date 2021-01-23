    public List<FileSystemInfo> GetTopFoldersAndFiles()
    {
        List<FileSystemInfo> FilesAndFolders = new List<FileSystemInfo>();
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("C://inetpub//wwwroot//Files//");
        di.GetDirectories();
        System.IO.FileInfo[] fiArr = di.GetFiles();
        foreach (DirectoryInfo t in di.GetDirectories())
        {
            FilesAndFolders.Add(t);
            foreach (FileInfo f in di.GetFiles())
            {
                FilesAndFolders.Add(f);
            }
        }
        return FilesAndFolders;
    }
