        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        private const int SW_MAXIMIZE = 9; //Command to restore the window
        
        [STAThread]
        static void Main()
        {
            bool onlyInstance = false;
            Mutex mutex = new Mutex(true, "UniqueApplicationName", out onlyInstance);
            if (!onlyInstance) 
            {
                 Process[] p = Process.GetProcessesByName("UniqueApplicationName");
                 SetForegroundWindow(p[0].MainWindowHandle);
                 ShowWindow(p[0].MainWindowHandle, SW_MAXIMIZE);
                 return;
            }
            Application.Run(new MainForm);
            GC.KeepAlive(mutex);
    }
