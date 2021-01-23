        public static Bitmap TakeScreenshot(Process process)
        {
            // may need a process Refresh before
            return TakeScreenshot(process.MainWindowHandle);
        }
        public static Bitmap TakeScreenshot(IntPtr handle)
        {
            RECT rc = new RECT();
            GetWindowRect(handle, ref rc);
            Bitmap bitmap = new Bitmap(rc.right - rc.left, rc.bottom - rc.top);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                PrintWindow(handle, graphics.GetHdc(), 0);
            }
            return bitmap;
        }
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);
        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hWnd, IntPtr hDC, int flags);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
