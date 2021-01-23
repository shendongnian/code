    public static class SingleApplication
    {
        [DllImport("user32.Dll")]
        private static extern int EnumWindows(EnumWinCallBack callBackFunc, int lParam);
        [DllImport("User32.Dll")]
        private static extern void GetWindowText(int hWnd, StringBuilder str, int nMaxCount);
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        static Mutex mutex;
        const int SW_RESTORE = 9;
        static string sTitle;
        static IntPtr windowHandle;
        delegate bool EnumWinCallBack(int hwnd, int lParam);
        private static bool EnumWindowCallBack(int hwnd, int lParam)
        {
            windowHandle = (IntPtr)hwnd;
            StringBuilder sbuilder = new StringBuilder(256);
            GetWindowText((int)windowHandle, sbuilder, sbuilder.Capacity);
            string strTitle = sbuilder.ToString();
            if (strTitle == sTitle && hwnd != lParam)
            {
                ShowWindow(windowHandle, SW_RESTORE);
                SetForegroundWindow(windowHandle);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Execute a form application. If another instance already running on the system activate previous one.
        /// </summary>
        /// <param name="frmMain">main form</param>
        /// <returns>true if no previous instance is running</returns>
        public static bool Run(System.Windows.Forms.Form frmMain)
        {
            if (IsAlreadyRunning())
            {
                sTitle = frmMain.Text;
                EnumWindows(new EnumWinCallBack(EnumWindowCallBack), frmMain.Handle.ToInt32());
                return false;
            }
            Application.Run(frmMain);
            return true;
        }
        /// <summary>
        /// Checks using a Mutex with the name of the running assembly's location
        /// </summary>
        /// <returns>True if the assembly is already launched from the same location, false otherwise.</returns>
        private static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetEntryAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string name = fileInfo.Name;
            mutex = new Mutex(true, name);
            if (mutex.WaitOne(0, false))
            {
                return false;
            }
            return true;
        }
    }
