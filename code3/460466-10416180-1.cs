    //added using statements per comments...
    using System.Diagnostics;
    using System.Runtime.InteropServices;
        internal sealed class Win32
        {
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            public static void HideConsoleWindow()
            {
                IntPtr hWnd = Process.GetCurrentProcess().MainWindowHandle;
    
                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, 0); // 0 = SW_HIDE
                }
            }
        }
