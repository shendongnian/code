    public IEnumerable<string> GetFilesRecursive(string ParentDirectory)
    {
        string[] subDirectories = Directory.GetDirectories(ParentDirectory);
        foreach (string file in Directory.GetFiles(ParentDirectory))
        {
            yield return file;
        }
        
        foreach (string subDirectory in subDirectories)
        {
            foreach (string file in GetFilesRecursive(subDirectory))
            {
                yield return file;
            }
        }
    }
