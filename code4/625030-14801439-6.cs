    /// <summary>
    /// The application's name
    /// </summary>
    public static string ApplicationName
    {
        get { return System.Windows.Forms.Application.ProductName; }
    }
    
    /// <summary>
    /// Common to all users, application's data directory.
    /// </summary>
    public static DirectoryInfo CommonDataDirectory
    {
        get
        {
            string fullName = Path.Combine(Company.CommonDataDirectory.FullName, ApplicationName);
            return new DirectoryInfo(fullName);
        }
    }
    
    /// <summary>
    /// Common to all users, file in application's data directory.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static FileInfo CommonDataFile(params string[] name)
    {
        string fullName = Paths.Combine(CommonDataDirectory.FullName, name);
        return new FileInfo(fullName);
    }
