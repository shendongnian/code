    public bool IsProcessOpen(string name)
    {
    foreach (Process process in Process.GetProcesses())
    {
    if (process.ProcessName.Contains(name))
    {
    return true;
    }
    }
    return false;
    }
