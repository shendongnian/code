        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0xA0) // WM_NCMOUSEMOVE
            {
                TrackNcMouseLeave(this);
                ShowClientArea();
            }
            else if (m.Msg == 0x2A2) // WM_NCMOUSELEAVE
            {
                HideClientArea();
            }
            else
                base.WndProc(ref m);
        }
        private int previouseHeight;
        private void ShowClientArea()
        {
            if (this.ClientSize.Height == 0)
                this.ClientSize = new Size(this.ClientSize.Width, previouseHeight);
        }
        private void HideClientArea()
        {
            previouseHeight = this.ClientSize.Height;
            this.ClientSize = new Size(this.ClientSize.Width, 0);
        }
        public static void TrackNcMouseLeave(Control control)
        {
            TRACKMOUSEEVENT tme = new TRACKMOUSEEVENT();
            tme.cbSize = (uint)Marshal.SizeOf(tme);
            tme.dwFlags = 2 | 0x10; // TME_LEAVE | TME_NONCLIENT
            tme.hwndTrack = control.Handle;
            TrackMouseEvent(tme);
        }
        [DllImport("user32")]
        public static extern bool TrackMouseEvent([In, Out] TRACKMOUSEEVENT lpEventTrack);
        [StructLayout(LayoutKind.Sequential)]
        public class TRACKMOUSEEVENT
        {
            public uint cbSize;
            public uint dwFlags;
            public IntPtr hwndTrack;
            public uint dwHoverTime;
        }
