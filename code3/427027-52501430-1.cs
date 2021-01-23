    public bool IsUnderIisExpress()
    {
        var currentProcess = Process.GetCurrentProcess();
        if (string.CompareOrdinal(currentProcess.ProcessName, "iisexpress") == 0)
        {
           return true;
        }
        var parentProcess = currentProcess.Parent();
        if (string.CompareOrdinal(parentProcess.ProcessName, "iisexpress") == 0
            || string.CompareOrdinal(parentProcess.ProcessName, "VSIISExeLauncher") == 0)
        {
            return true;
        }
        return false;
    }
