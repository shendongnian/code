    public static DirectoryInfo ProgramDirectory
    {
        get
        {
            string executablePath = System.Windows.Forms.Application.StartupPath;
            return new DirectoryInfo(executablePath);
        }
    }
    
    /// <summary>
    /// Get's the file in the exectuable's directory, which would be
    /// ProgramFiles/applicationName/filename
    /// </summary>
    public static FileInfo ProgramFile(params string[] path)
    {
        string file = Paths.Combine(ProgramDirectory.FullName, path);
        return new FileInfo(file);
    }
