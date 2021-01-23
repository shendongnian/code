    public static bool HasExecutable(string path)
    {
        var executable = FindExecutable(path);
        return !string.IsNullOrEmpty(executable);
    }
    
    private static string FindExecutable(string path)
    {
        var executable = new StringBuilder(1024);
        FindExecutable(path, string.Empty, executable);
        return executable.ToString();
    }
    
    [DllImport("shell32.dll", EntryPoint = "FindExecutable")]
    private static extern long FindExecutable(string lpFile, string lpDirectory, StringBuilder lpResult);
