    public static string[] GetNewFiles(string directory, string searchPattern, DateTime since)
    {
        // Create a new DirectoryInfo object.
        DirectoryInfo dir = new DirectoryInfo(directory);
        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException("The directory does not exist.");
        }
        // Call the GetFileSystemInfos method.
        FileSystemInfo[] infos = dir.GetFileSystemInfos(searchPattern);
        string[] newXmlFiles = (from info in infos
                               where info.CreationTime > since
                               select info.FullName).ToArray();
        return newXmlFiles;
    }
    public static string[] GetModifiedFiles(string directory, string searchPattern, DateTime since)
    {
        // Create a new DirectoryInfo object.
        DirectoryInfo dir = new DirectoryInfo(directory);
        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException("The directory does not exist.");
        }
        // Call the GetFileSystemInfos method.
        FileSystemInfo[] infos = dir.GetFileSystemInfos(searchPattern);
        string[] newXmlFiles = (from info in infos
                               where info.LastWriteTime > since
                               select info.FullName).ToArray();
        return newXmlFiles;
    }
