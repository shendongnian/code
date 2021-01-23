            [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        const int LVM_FIRST = 0x1000;
        const int LVM_GETHEADER = (LVM_FIRST + 31);
        public CustomListView()
        {
            VisibleChanged += (s, e) =>
            {
                if (Visible && headerHandle == IntPtr.Zero && !DesignMode)
                {
                    IntPtr hwnd = SendMessage(this.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
                    if (hwnd != null)
                    {
                        headerProc = new HeaderProc(this);
                        headerHandle = hwnd;
                        headerProc.AssignHandle(hwnd);
                    }
                }
            };
            columnPipeLefts[0] = 0;
        }
