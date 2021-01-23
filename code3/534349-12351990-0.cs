        [DllImport("user32.dll")]
        private static extern int FindWindow(string lpszClassName, string lpszWindowName);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hWnd, int nCmdShow);
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;
        public void WindowsToolbar(bool visible)
        {
            int hWnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hWnd, visible ? SW_SHOW : SW_HIDE);
        }
        public void HideTaskBarIfNeeded(Form form)
        {
            if (Screen.PrimaryScreen.Equals(Screen.FromRectangle(Screen.GetBounds(form))))
            {
                WindowsToolbar(false);
            }
        }
