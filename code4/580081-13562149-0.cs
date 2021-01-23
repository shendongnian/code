        public static bool KillProcess(string yourProcessName)
    {
        foreach (Process clsProcess in Process.GetProcesses())
        {
            if (Process.GetCurrentProcess().Id == clsProcess.Id)
                continue;
            if (clsProcess.ProcessName.Contains(name))
            {
                clsProcess.Kill();
                return true;
            }
        }
        return false;
    }
