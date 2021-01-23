    private ProcessStartInfo CreateStartInfo(string command, string args, string workingDirectory, bool useShellExecute)
    {
        var defaultWorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        var result = new ProcessStartInfo
        {
            WorkingDirectory = string.IsNullOrEmpty(workingDirectory) 
                                     ? defaultWorkingDirectory 
                                     : workingDirectory,
            FileName = command,
            Arguments = args,
            UseShellExecute = useShellExecute,
            CreateNoWindow = true,
            ErrorDialog = false,
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardOutput = !useShellExecute,
            RedirectStandardError = !useShellExecute,
            RedirectStandardInput = !useShellExecute
        };
        return result;
    }
