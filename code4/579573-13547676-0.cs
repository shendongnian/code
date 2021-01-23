    public static IntPtr WinGetHandle(string wName)
    {
        IntPtr hwnd = IntPtr.Zero;
        foreach (Process pList in Process.GetProcesses())
        {
            if (pList.MainWindowTitle.Contains(wName))
            {
                hWnd = pList.MainWindowHandle;
            }
        }
        return hWnd;
    }
