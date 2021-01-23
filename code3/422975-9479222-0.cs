        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            ShowScrollBar(this.Handle, 1, false);
            base.WndProc(ref m);
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
