    using System.Diagnostics;
    private bool ApplicationExists(string appName)
    {
        foreach (Process currentProcess in Process.GetProcesses("."))
        {
            if (currentProcess.MainWindowTitle.Length == appName)
            {
                return true;
            }
        }
        return false;
    }
