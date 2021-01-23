    private List<string> GetAllFolders()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(this.sourceFolder);
        List<string> allFolders = new List<string>();
        foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories(("*.*", SearchOption.AllDirectories))
        {
            //logic
            allFolders.Add(subDirectoryInfo.FullName);
        }
        return allFolders;
    }
