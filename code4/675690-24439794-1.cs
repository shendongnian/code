    static seen = new HashSet<string>();
    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN)
        {
            IntPtr hwnd2 = GetForegroundWindow();
            StringBuilder windowtitle = new StringBuilder(256);
            if (GetWindowText(hwnd2, windowtitle, windowtitle.Capacity) > 0) 
            {
                var title = windowtitle.ToString();
                if (!seen.Contains(title))
                {
                   seen.Add(title);
                   Console.WriteLine(title);
                }
            }
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }
