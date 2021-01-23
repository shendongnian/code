    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class ExtendedTreeView : TreeView {
        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_REFLECT + WM_NOFITY) {
                var notify = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));
                if (notify.code == NM_CLICK) {
                    MessageBox.Show("yada");
                    m.Result = (IntPtr)1;
                    return;
                }
    
            }
            base.WndProc(ref m);
        }
        private const int NM_FIRST = 0;
        private const int NM_CLICK = NM_FIRST - 2;
        private const int WM_REFLECT = 0x2000;
        private const int WM_NOFITY = 0x004e;
    
        [StructLayout(LayoutKind.Sequential)]
        private struct NMHDR {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public int code;
        }
    }
