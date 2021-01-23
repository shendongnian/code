    using System;
    using System.Windows.Forms;
    
    class MyListView : ListView
    {
        public event ScrollEventHandler Scroll;
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int MOUSEWHEEL = 0x020A;
        private const int KEYDOWN = 0x0100;
    
        protected virtual void OnScroll(ScrollEventArgs e)
        {
            ScrollEventHandler handler = this.Scroll;
            if (handler != null) handler(this, e);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == MOUSEWHEEL || m.Msg == WM_VSCROLL || (m.Msg == KEYDOWN && (m.WParam == (IntPtr)40 || m.WParam == (IntPtr)35)))
            {
                // Trap WM_VSCROLL 
                OnScroll(new ScrollEventArgs((ScrollEventType)(m.WParam.ToInt32() & 0xffff), 0));
            }
        }
    }
    
