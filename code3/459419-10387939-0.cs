    int hWnd;
    Process[] processRunning = Process.GetProcesses();
    foreach (Process pr in processRunning)
    {
        if (pr.ProcessName == "notepad")
        {
            hWnd = pr.MainWindowHandle.ToInt32();
            ShowWindow(hWnd, SW_HIDE);
        }
    }
