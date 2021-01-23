        private const int WM_SCROLL = 276; // Horizontal scroll 
        private const int SB_LINELEFT = 0; // Scrolls one cell left 
        private const int SB_LINERIGHT = 1; // Scrolls one line right
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam); 
        private void panelInner_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
            {
                var direction = e.Delta > 0 ? SB_LINELEFT : SB_LINERIGHT;
                SendMessage(this.richTextBox.Handle, WM_SCROLL, (IntPtr)direction, IntPtr.Zero);
            }
        }
