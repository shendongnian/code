    public static string[] GetFiles(string path, string filename)
    {
        string fullPath = Path.Combine(path, "pool");
        return System.IO.Directory.GetFiles(fullPath, filename, SearchOption.AllDirectories);   
    }
