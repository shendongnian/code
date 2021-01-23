    public bool HasExecutable(string path)
    {
        var executable = FindExecutable(path);
        return !string.IsNullOrEmpty(executable);
    }
    
    private string FindExecutable(string path)
    {
        var executable = new StringBuilder(1024);
        var result = FindExecutable(path, string.Empty, executable);
        return result >= 32 ? executable.ToString() : string.Empty;
    }
    
    [DllImport("shell32.dll", EntryPoint = "FindExecutable")]
    private static extern long FindExecutable(string lpFile, string lpDirectory, StringBuilder lpResult);
