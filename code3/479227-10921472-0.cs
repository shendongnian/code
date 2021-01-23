    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class MyDateTimePicker : DateTimePicker {
        protected override void OnHandleCreated(EventArgs e) {
            int style = (int)SendMessage(this.Handle, DTM_GETMCSTYLE, IntPtr.Zero, IntPtr.Zero);
            style |= MCS_NOTODAY | MCS_NOTODAYCIRCLE;
            SendMessage(this.Handle, DTM_SETMCSTYLE, IntPtr.Zero, (IntPtr)style);
            base.OnHandleCreated(e);
        }
        //pinvoke:
        private const int DTM_FIRST = 0x1000;
        private const int DTM_SETMCSTYLE = DTM_FIRST + 11;
        private const int DTM_GETMCSTYLE = DTM_FIRST + 12;
        private const int MCS_NOTODAYCIRCLE = 0x0008;
        private const int MCS_NOTODAY = 0x0010;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
