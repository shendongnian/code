            public Form1()
        {
            InitializeComponent();
            if (!WTSRegisterSessionNotification(this.Handle, NOTIFY_FOR_THIS_SESSION))
            {
                Marshal.ThrowExceptionForHR(Marshal.GetLastWin32Error());
            }
        }
        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);
        [DllImport("WtsApi32.dll")]
        private static extern bool WTSRegisterSessionNotification(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)]int dwFlags);
        [DllImport("WtsApi32.dll")]
        private static extern bool WTSUnRegisterSessionNotification(IntPtr hWnd);
        // constants that can be passed for the dwFlags parameter
        const int NOTIFY_FOR_THIS_SESSION = 0;
        const int NOTIFY_FOR_ALL_SESSIONS = 1;
        // message id to look for when processing the message (see sample code)
        const int WM_WTSSESSION_CHANGE = 0x2b1;
        
        // WParam values that can be received: 
        const int WTS_CONSOLE_CONNECT = 0x1; // A session was connected to the console terminal.
        const int WTS_CONSOLE_DISCONNECT = 0x2; // A session was disconnected from the console terminal.
        const int WTS_REMOTE_CONNECT = 0x3; // A session was connected to the remote terminal.
        const int WTS_REMOTE_DISCONNECT = 0x4; // A session was disconnected from the remote terminal.
        const int WTS_SESSION_LOGON = 0x5; // A user has logged on to the session.
        const int WTS_SESSION_LOGOFF = 0x6; // A user has logged off the session.
        const int WTS_SESSION_LOCK = 0x7; // A session has been locked.
        const int WTS_SESSION_UNLOCK = 0x8; // A session has been unlocked.
        const int WTS_SESSION_REMOTE_CONTROL = 0x9; // A session has changed its remote controlled status.
        protected override void OnHandleDestroyed(EventArgs e)
        {
            // unregister the handle before it gets destroyed
            WTSUnRegisterSessionNotification(this.Handle);
            base.OnHandleDestroyed(e);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_WTSSESSION_CHANGE)
            {
                int value = m.WParam.ToInt32();
                if (value == WTS_REMOTE_DISCONNECT)
                {
                    ExitWindowsEx(4, 0); // Logout the user on disconnect
                }
                else if (value == WTS_REMOTE_CONNECT)
                {
                    MessageBox.Show("Welcome to the VPN. There is no need to Logout anymore, as when you close this session it will automatically log you out");
                }
            }
            base.WndProc(ref m);
        }
