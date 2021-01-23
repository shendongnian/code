    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    static void Main(string[] args)
    {
        Process[] processes = Process.GetProcessesByName("game");
        Process game1 = processes[0];
        
        IntPtr p = game1.MainWindowHandle;
        SetForegroundWindow(p);
        SendKeys.SendWait("{DOWN}");
        Thread.Sleep(1000);
        SendKeys.SendWait("{DOWN}");
    }
