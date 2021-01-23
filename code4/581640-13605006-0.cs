        const int WM_CLOSE = 0x10;
        const int INTERNET_AUTODIAL_FORCE_UNATTENDED = 0x2;
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(int hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int InternetDial(IntPtr hWndParent, string pszEntryName, int dwFlags, ref int lpdwConnection, int ReservedValue);
            public static bool GetOnline()
            {
                connectionID = 0;
                Form f = null;
                var t = new Thread((ParameterizedThreadStart)delegate
                {
                    f = new Form();                
                    InternetDial(f.Handle, "DefaultDialUp", INTERNET_AUTODIAL_FORCE_UNATTENDED, ref connectionID, 0);
                });
                t.Start();
                t.Join(23000); //wait 23 seconds before closing the window
                f.Invoke((EventHandler)delegate {
                    PostMessage(f.Handle.ToInt32(), WM_CLOSE, IntPtr.Zero, IntPtr.Zero);            
                });
                t.Join();            
                return (connectionID != 0);            
            }
