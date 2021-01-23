    static string lastseen = null;
    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN)
        {
            IntPtr hwnd2 = GetForegroundWindow();
            StringBuilder windowtitle = new StringBuilder(256);
            if (GetWindowText(hwnd2, windowtitle, windowtitle.Capacity) > 0) 
            {
                var title = windowtitle.ToString();
                if (!String.Equals(lastseen, title)
                {
                   lastseen = title;
                   Console.WriteLine(lastseen);
                }
            }
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }
