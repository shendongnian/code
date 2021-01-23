    [DllImport("user32.dll")]
            private static extern bool GetWindowRect(IntPtr hwnd, ref Rectangle rectangle);
    [DllImport("user32.dll", SetLastError = true)]
                internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    [DllImport("user32.dll")]
                public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        public const uint WM_SYSCOMMAND = 0x0112;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_NEXTWINDOW = 0xF040;
        public const int SW_FORCEMINIMIZE = 11;
        public const int SW_HIDE = 0;
        public const int SW_MAXIMIZE = 3;
        public const int SW_MINIMIZE = 6;
        public const int SW_RESTORE = 9;
        public const int SW_SHOW = 5;
        public const int SW_SHOWDEFAULT = 10;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMINNOCATIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOWNORMAL = 1;
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWRECTANGLE
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        /// <summary>
        /// Puts all the active screens on the primairy screen.
        /// </summary>
        public static void putAllWindowsOnPrimairyScreen()
        {
            foreach (Process p in Process.GetProcesses())
            {
                int procesWidth, procesHeigth;
                IntPtr id = p.MainWindowHandle;
                WINDOWRECTANGLE rect = new WINDOWRECTANGLE();
                GetWindowRect(id, ref rect);
                if (!string.IsNullOrEmpty(p.MainWindowTitle))
                {
                    procesWidth = rect.Right - rect.Left;
                    procesHeigth = rect.Bottom - rect.Top;
                    ShowWindow(id, SW_RESTORE);
                    PostMessage(p.Handle, WM_SYSCOMMAND, SC_NEXTWINDOW, 0);
                    MoveWindow(id, 0, 0, procesWidth, procesHeigth, true);
                    p.Refresh();
                    if (procesHeigth >= Screen.PrimaryScreen.Bounds.Height || procesWidth >= Screen.PrimaryScreen.Bounds.Width) ShowWindow(id, SW_MAXIMIZE);
                }
            }
        }
