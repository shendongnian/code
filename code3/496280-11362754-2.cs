    internal sealed class NonScrollableWindow : NativeWindow
    {
        private readonly MdiClient _mdiClient;
        public NonScrollableWindow(MdiClient parent)
        {
            _mdiClient = parent;
            ReleaseHandle();
            AssignHandle(_mdiClient.Handle);
        }
        internal void OnHandleDestroyed(object sender, EventArgs e)
        {
            ReleaseHandle();
        }
        private const int SB_BOTH = 3;
        [DllImport("user32.dll")]
        private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);
        protected override void WndProc(ref Message m)
        {
            ShowScrollBar(m.HWnd, SB_BOTH, 0);
            base.WndProc(ref m);
        }
    }
