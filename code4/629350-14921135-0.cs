    public void DoDirectories()
    {
        // one-time part; get a list of directories to start with.
        List<string> rootDirectories = Directory.GetDirectories("c:\\").ToList();
        foreach (string rootDirectory in rootDirectories)
        {
            GetSubdirectories(rootDirectory);
        }
    }
    
    public List<string> GetSubdirectories(string parentDirectory)
    {
        List<string> subdirecotries = Directory.GetDirectories(
            parentDirectory, "*.*", SearchOption.TopDirectoryOnly).ToList();
        foreach (string subdirectory in subdirecotries)
        {
            GetSubdirectories(subdirectory); // recursing happens here
        }
        return subdirecotries;
    }
