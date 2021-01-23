    bool CheckIfProcessIsRunning(string nameSubstring)
    {
        foreach (Process clsProcess in Process.GetProcesses())
        {
            if (clsProcess.ProcessName.Contains(nameSubstring))
            {
                return true;
            }
        }
        return false;
    }
