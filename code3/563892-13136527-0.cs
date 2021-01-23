    public bool IsProcessOpen(string name)
    {
        foreach (Process clsProcess in Process.GetProcesses())
        {
            if (clsProcess.ProcessName.Contains(Path.GetFileNameWithoutExtension(name)))
            {
                return true;
            }
        }
        return false;
    }
