    DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
    /// <summary>
    /// Enumeration of the different ways of showing a window using 
    /// ShowWindow</summary>
    private enum WindowShowStyle : uint
    {
        Hide = 0,
        ShowNormal = 1,
        ShowMinimized = 2,
        ShowMaximized = 3,
        // Many more, but this one seems the one required
        /// <summary>Activates and displays the window. If the window is 
        /// minimized or maximized, the system restores it to its original size 
        /// and position. An application should specify this flag when restoring 
        /// a minimized window.</summary>
        /// <remarks>See SW_RESTORE</remarks>
        Restore = 9
    }
    IntPtr mainWin = Process.GetProcessByID(appIdentifier).MainWindowHandle;
    ShowWindow(mainWin, WindowShowStyle.Restore);
