    private static bool ConfirmProcessIsOnProperMonitor(IntPtr windowHandler, int monitor)
    {
        //make sure you don't go to an incorrect monitor
        if (monitor >= Screen.AllScreens.Count()) monitor = Screen.AllScreens.Count() - 1;
        RECT windowRec = new RECT();
        GetWindowRect(windowHandler, ref windowRec);
        if (windowRec.Left != Screen.AllScreens[monitor].WorkingArea.Left || windowRec.Top != Screen.AllScreens[monitor].WorkingArea.Top)
            return false;
        else
            return true;
    }
    private static void MoveWindowToMonitor(IntPtr windowHandler, int monitor)
    {
        //make sure you don't go to an incorrect monitor
        if (monitor >= Screen.AllScreens.Count()) monitor = Screen.AllScreens.Count() - 1;
        RECT windowRec = new RECT();
        GetWindowRect(windowHandler, ref windowRec);
        int width = windowRec.Right - windowRec.Left;
        int height = windowRec.Top - windowRec.Bottom;
        if (width < 0)
            width = width * -1;
        if (height < 0)
            height = height * -1;
        SetWindowPos(windowHandler, (IntPtr)SpecialWindowHandles.HWND_TOP, Screen.AllScreens[monitor].WorkingArea.Left,
                Screen.AllScreens[monitor].WorkingArea.Top, width, height, SetWindowPosFlags.SWP_SHOWWINDOW);
    }
    protected static bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
    {
        int size = GetWindowTextLength(hWnd);
        if (size++ > 0 && IsWindowVisible(hWnd))
        {
            StringBuilder sb = new StringBuilder(size);
            GetWindowText(hWnd, sb, size);
            string windowText = sb.ToString();
            if (windowText.ToLower().Contains(_baseURL) || windowText.ToLower().Contains("internet explorer"))
            {
                string url = GetURL(hWnd);
                _windowhandles.Add(hWnd, url);
            }
        }
        return true;
    }
    private static string GetURL(IntPtr intPtr)
    {
        foreach (InternetExplorer ie in new ShellWindows())
        {
            if (ie.HWND == intPtr.ToInt32())
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ie.FullName);
                if ((fileNameWithoutExtension != null) && fileNameWithoutExtension.ToLower().Equals("iexplore"))
                {
                    return ie.LocationURL;
                }
                else
                {
                    return null;
                }
            }
        }
        return null;
    }
