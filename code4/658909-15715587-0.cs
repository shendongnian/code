    Process[] processes = Process.GetProcessesByName("appName");
    Process p = processes.FirstOrDefault();
    IntPtr windowHandle;
    if (p != null)
    {
        windowHandle = p.MainWindowHandle;
    }
