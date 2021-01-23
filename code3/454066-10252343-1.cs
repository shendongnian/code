    const uint WM_CLOSE = 0x10;
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd, uint uMsg, int wParam, int lParam);
    Process p = Process.GetProcessesByName("notepad").FirstOrDefault();
    if(p != null)
    {
        IntPtr hWnd = p.MainWindowHandle;
        SendMessage(hWnd, WM_CLOSE, 0, 0);
    }
