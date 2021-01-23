        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        public enum WMessages : int
        {
            WM_LBUTTONDOWN = 0x201,
            WM_LBUTTONUP = 0x202
        }
        private int MAKELPARAM(int p, int p_2)
        {
            return ((p_2 << 16) | (p & 0xFFFF));
        }
        public void DoMouseLeftClick(IntPtr handle, Point x)
        {
            PostMessage(handle, (uint)WMessages.WM_LBUTTONDOWN, 0, MAKELPARAM(x.X, x.Y));
            PostMessage(handle, (uint)WMessages.WM_LBUTTONUP, 0, MAKELPARAM(x.X, x.Y));            
        }
        
