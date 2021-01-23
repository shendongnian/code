    static void BringWindowToFront()
    {
        var currentProcess = Process.GetCurrentProcess();
        var processes = Process.GetProcessesByName(currentProcess.ProcessName);
        var process = processes.FirstOrDefault(p => p!=currentProcess);
        if (process == null) return;
        SetForegroundWindow(process.MainWindowHandle);
    }
    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
