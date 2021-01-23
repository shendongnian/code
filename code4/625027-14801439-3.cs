    public const string Company = "YourCompanyName";
    /// <summary>
    /// Common to all users Company data directory.
    /// </summary>
    public static DirectoryInfo CommonDataDirectory
    {
        get
        {
            string env = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string path = Path.Combine(env, Company);
            return new DirectoryInfo(path);
        }
    }
    
    /// <summary>
    /// Common to all users data file.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static FileInfo CommonDataFile(params string[] path)
    {
        string fullName = Paths.Combine(CommonDataDirectory.FullName, path);
        return new FileInfo(fullName);
    }
