    public Tuple<List<DirectoryInfo>,List<FileInfo>> GetTopFolders()
    {
        List<DirectoryInfo> Folders = new List<DirectoryInfo>();
        List<FileInfo> Files = new List<FileInfo>();
         /* All your other code here */
         /* Removed for brevity*/
        foreach (DirectoryInfo t in di.GetDirectories())
        {
            Folders.Add(t);
            foreach (FileInfo f in di.GetFiles())
            {
                Files.Add(f);
            }
        }
        return Tuple.Create(Folders, Files);
    }
