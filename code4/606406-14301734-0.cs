    var appProcessName = Process.GetCurrentProcess().ProcessName;
    var matchingProcesses = Process.GetProcessesByName(appProcessName);
    if (matchingProcesses.Any())
    {
        // Exit
    }
