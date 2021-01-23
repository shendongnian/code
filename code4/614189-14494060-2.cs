    Process[] processes = Process.GetProcessesByName("firefox.exe");
    foreach (Process p in processes)
    {
        if (p.ProcessName.Equals("firefox.exe", StringComparison.OrdinalIgnoreCase))
        {
            p.Kill();
        }
    }
