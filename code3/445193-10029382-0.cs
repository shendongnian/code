        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);
        protected override void WndProc(ref Message m)
        {
            const int WM_MOVE = 0x0003;
            const int WM_ENTERSIZEMOVE = 0x0231;
            const int WM_EXITSIZEMOVE = 0x0232;
            const int SB_BOTH = 3;
            
            switch (m.Msg)
            {
                // Use SuspendLayout() instead of having constant flickering on resize starting
                case WM_ENTERSIZEMOVE:
                    this.SuspendLayout();
                    base.WndProc(ref m);
                    break;
                // Do not forget to ResumeLayout() when resizing finished
                case WM_EXITSIZEMOVE:
                    this.ResumeLayout();
                    base.WndProc(ref m);
                    break;
                default:
                    ShowScrollBar(this.Handle, SB_BOTH, 0);
                    base.WndProc(ref m);
                    break;
            }
        }
