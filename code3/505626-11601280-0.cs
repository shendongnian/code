    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class MdiScroller : NativeWindow {
        public static void Install(Form mdiParent) {
            if (!mdiParent.IsMdiContainer) throw new ArgumentException("Not an MDI application");
            if (!mdiParent.IsHandleCreated) throw new InvalidOperationException("Create me in the Load event please");
            foreach (Control ctl in mdiParent.Controls) {
                if (ctl is MdiClient) {
                    var hooker = new MdiScroller();
                    hooker.AssignHandle(ctl.Handle);
                    break;
                }
            }
        }
    
        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_DESTROY) this.ReleaseHandle();
            if (m.Msg == WM_MOUSEWHEEL) {
                short delta = (short)((int)(long)m.WParam >> 16);
                SendMessage(this.Handle, WM_VSCROLL, (IntPtr)(delta < 0 ? SB_LINEUP : SB_LINEDOWN), IntPtr.Zero);
                m.Result = IntPtr.Zero;
            }
            base.WndProc(ref m);
        }
    
        // PInvoke:
        private const int WM_DESTROY = 0x002;
        private const int WM_MOUSEWHEEL = 0x20a;
        private const int WM_VSCROLL = 0x115;
        private const int SB_LINEDOWN = 0;
        private const int SB_LINEUP = 1;
    
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    
    }
