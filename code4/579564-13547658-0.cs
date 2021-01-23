    public static IntPtr WinGetHandle(string wName){
        IntPtr hWnd = NULL;
        foreach (Process pList in Process.GetProcesses())
            if (pList.MainWindowTitle.Contains(wName))
                hWnd = pList.MainWindowHandle;
        return hWnd;
    }
