        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern bool LockWindowUpdate(IntPtr hWndLock);
        public new void BeginUpdate()
        {
            SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero);
            LockWindowUpdate(this.Handle);
        }
        public new void EndUpdate()
        {
            LockWindowUpdate(IntPtr.Zero);
            SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
        }
