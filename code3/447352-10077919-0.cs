    private static string fixupPath (string dir)
    {
        return Path.Combine(RootPath() + dir); 
    }
    
    public static string File1
    {
        get { return fixupPath(File1RelativePath); }
    }
