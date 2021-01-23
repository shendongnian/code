    Process[] processes = Process.GetProcesses();
    try
    {
        foreach (Process p in processes)
            if (p.ProcessName.EndsWith(".scr"))
                return true;
    }
    finally
    {
        foreach (Process p in processes)
            p.Dispose();
    }
