    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class SampleControl : Control
    {
        [DllImport("user32.dll")]
        private static extern int TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);
        [StructLayout(LayoutKind.Sequential)]
        private struct TRACKMOUSEEVENT
        {
            public uint cbSize;
            public uint dwFlags;
            public IntPtr hwndTrack;
            public uint dwHoverTime;
            public static readonly TRACKMOUSEEVENT Empty;
        }
        private TRACKMOUSEEVENT track = TRACKMOUSEEVENT.Empty;
        const int WM_MOUSEMOVE = 0x0200;
        const int WM_MOUSEHOVER = 0x02A1;
        const int TME_HOVER = 0x1;
        const int TME_LEAVE = 0x2;
        public event EventHandler MyMouseHover;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEMOVE)
            {
                track.hwndTrack = this.Handle;
                track.cbSize = (uint)Marshal.SizeOf(track);
                track.dwFlags = TME_HOVER | TME_LEAVE;
                track.dwHoverTime = 500;
                TrackMouseEvent(ref track);
            }
            if(m.Msg == WM_MOUSEHOVER)
            {
                MyMouseHover?.Invoke(this, EventArgs.Empty);
            }
            base.WndProc(ref m);
        }
    }
