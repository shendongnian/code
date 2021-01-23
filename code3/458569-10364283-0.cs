    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class BufferedTreeView : TreeView {
        protected override void OnHandleCreated(EventArgs e) {
            int style = (int)SendMessage(this.Handle, TVM_GETEXTENDEDSTYLE, IntPtr.Zero, IntPtr.Zero);
            style |= TVS_EX_DOUBLEBUFFER;
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, this.Handle, (IntPtr)style);
            base.OnHandleCreated(e);
        }
        // Pinvoke:
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
