    public IEnumerable<FileInfo> FindFilesInDirectory(string dirPath, string searchName)
    {
        if (Directory.Exists(dirPath))
        {
            var dir = new DirectoryInfo(dirPath);
            return dir.EnumerateFiles("*.*", SearchOption.AllDirectories)
                      .Where(fi => fi.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        }
        else
            throw new ArgumentException("Directory doesn't exist.", dirPath);
    }
