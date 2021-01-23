    protected override OnStart(string[] args)
    {
        int processId;
        IntPtr ptr = GetForegroundWindow();
        GetWindowThreadProcessId(ptr, out processId);
        var process = Process.GetProcessById(processId);
        if (String.CompareOrdinal(process.ProcessName, "cmd") == 0)
        {
            // Hijack an existing foreground cmd window.
            AttachConsole(process.Id);
        }
        else
        {
            // Or create a new one
            AllocConsole();
        }
    }
    protected override OnStop()
    {
        FreeConsole();
    }
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AllocConsole();
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool FreeConsole();
    [DllImport("kernel32", SetLastError = true)]
    static extern bool AttachConsole(int dwProcessId);
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
