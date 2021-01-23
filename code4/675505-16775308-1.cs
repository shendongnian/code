    public static bool FileExistsCaseSensitive(string filename)
    {
        string name = Path.GetDirectoryName(filename);
        return name != null 
               && Array.Exists(Directory.GetFiles(name), s => s == Path.GetFullPath(filename));
    }
