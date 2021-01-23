        private const int WM_NCHITTEST = 0x84;
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MINIMIZE = 0xf020;
        private const int SC_MAXIMIZE = 0xf030;
        private const int SC_RESTORE = 0xf120;
        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_SYSCOMMAND) {
                switch (m.WParam.ToInt32() & 0xfff0) {
                    case SC_MINIMIZE: Console.WriteLine("Minimize"); break;
                    case SC_MAXIMIZE: Console.WriteLine("Maximize"); break;
                    case SC_RESTORE:  Console.WriteLine("Restore");  break;
                }
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && m.Result == (IntPtr)1) m.Result = (IntPtr)2;
        }
