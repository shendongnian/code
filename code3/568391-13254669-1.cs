        [DllImport("comctl32.dll", SetLastError=true,  EntryPoint="#383")]
        static extern void DoReaderMode(ref READERMODEINFO prmi);
        public delegate bool TranslateDispatchCallbackDelegate(ref MSG lpmsg);
        public delegate bool ReaderScrollCallbackDelegate(ref READERMODEINFO prmi, int dx, int dy);
        [StructLayout(LayoutKind.Sequential)]
        public struct READERMODEINFO
        {
            public int cbSize;
            public IntPtr hwnd;
            public int fFlags;
            public IntPtr prc;
            public ReaderScrollCallbackDelegate pfnScroll;
            public TranslateDispatchCallbackDelegate fFlags2;
            public IntPtr lParam;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public UInt32 message;
            public IntPtr wParam;
            public IntPtr lParam;
            public UInt32 time;
            public POINT pt;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int left, top, right, bottom;
        }
        private bool TranslateDispatchCallback(ref MSG lpMsg)
        {
            return false;
        }
        private bool ReaderScrollCallback(ref READERMODEINFO prmi, int dx, int dy)
        {
            // TODO: Scroll around within your control here
            return false;
        }
        private void EnterReaderMode()
        {
            READERMODEINFO readerInfo = new READERMODEINFO
            {
                hwnd = this.textBox1.Handle,
                fFlags = 0x00,
                prc = IntPtr.Zero,
                lParam = IntPtr.Zero,
                fFlags2 = new TranslateDispatchCallbackDelegate(this.TranslateDispatchCallback),
                pfnScroll = new ReaderScrollCallbackDelegate(this.ReaderScrollCallback)
            };
            readerInfo.cbSize = Marshal.SizeOf(readerInfo);
            DoReaderMode(ref readerInfo);
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                EnterReaderMode();
            }
        }
