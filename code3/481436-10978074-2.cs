        private static Size GetMaximizedClientSize(Form form)
        {
            var original = form.WindowState;
            try
            {
                BeginUpdate(form);
                form.WindowState = FormWindowState.Maximized;
                return form.ClientSize;
            }
            finally
            {
                form.WindowState = original;   
                EndUpdate(form);
            }
        }
        [DllImport("User32.dll")]
        private extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        private enum Message : int
        {
            WM_SETREDRAW = 0x000B, // int 11
        }
        /// <summary>
        /// Calls user32.dll SendMessage(handle, WM_SETREDRAW, 0, null) native function to disable painting
        /// </summary>
        /// <param name="c"></param>
        public static void BeginUpdate(Control c)
        {
            SendMessage(c.Handle, (int)Message.WM_SETREDRAW, new IntPtr(0), IntPtr.Zero);
        }
        /// <summary>
        /// Calls user32.dll SendMessage(handle, WM_SETREDRAW, 1, null) native function to enable painting
        /// </summary>
        /// <param name="c"></param>
        public static void EndUpdate(Control c)
        {
            SendMessage(c.Handle, (int)Message.WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
        }
