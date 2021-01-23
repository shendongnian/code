    void ExitAll(string processName)
    {
        foreach(Process p in Process.GetProcesses())
        {
            if (p.ProcessName.ToLower().Equals(processName))
                p.Kill();
        }
    }
