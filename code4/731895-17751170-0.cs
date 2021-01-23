    public static string GetDataDirectory(string root)
    {
        var directoryList = Directory.GetDirectories(root);
        if (!directoryList.Any())
            return null;
        directoryList = directoryList.OrderBy(dir => dir).ToArray();
        return directoryList.First();
    }    
