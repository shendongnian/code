    private static bool IsLastClientClosed()
    {
        var processes = Process.GetProcesses();
    
        var debuggingProcesses = processes.Where(p => p.ProcessName.Contains("Bar1.vshost") || p.ProcessName.Contains("Bar2.vshost")).ToList();
        if (debuggingProcesses.Any())
            return !DebuggingRuns(debuggingProcesses);
    
        return processes.Any(p => p.ProcessName.StartsWith("Bar1") || p.ProcessName.StartsWith("Bar2"));
    }
    
    private static bool DebuggingRuns(IEnumerable<Process> processes)
    {
        foreach (var process in processes)
        {
            try
            {
                if (!string.IsNullOrEmpty(process.MainWindowTitle))
                    return true;
            }
            catch
            {
            }
        }
        return false;
    }
