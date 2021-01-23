    private sealed class RouteKeyDownMessageFilter : IMessageFilter
    {
        private readonly Control mControl;
        private readonly Keys mKey;
        public RouteKeyDownMessageFilter(Control control, Keys key)
        {
            this.mControl = control;
            this.mKey = (Keys.KeyCode & key);
        }
        public bool PreFilterMessage(ref Message m)
        {
            if ((m.Msg == WM_KEYDOWN) &&
                (m.HWnd == this.mControl.Handle) &&
                (((Keys)m.WParam & Keys.KeyCode) == this.mKey))
            {
                SendMessage(m.HWnd, m.Msg, m.WParam, m.LParam);
            }
            return false;
        }
        public const int WM_KEYDOWN = 0x0100;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
