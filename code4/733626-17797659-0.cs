    static bool CheckIfProcessRunning(string someCommonRepeatingPortionName)
    {
        return Process.GetProcesses().Any(
            p => p.ProcessName.Contains(someCommonRepeatingPortionName));
    }
