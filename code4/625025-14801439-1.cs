    /// <summary>
    /// User's common data directory
    /// </summary>
    /// <returns></returns>
    public static DirectoryInfo UserDataDirectory
    {
        get
        {
            string env = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(env, Company);
            return new DirectoryInfo(path);
        }
    }
    
    /// <summary>
    /// File in user's common data directory
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static FileInfo UserDataFile(params string[] path)
    {
        return new FileInfo(Paths.Combine(UserDataDirectory.FullName, path));
    }
