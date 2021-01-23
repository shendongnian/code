    private static void killps(string processName)
    {
        Process[] process = Process.GetProcessesByName(processName);
        Process current = Process.GetCurrentProcess();
        foreach (Process p in process)
        {
            if (p.Id != current.Id)
            p.Kill();
        }
    }
