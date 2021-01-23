        private static FieldInfo _internalVirtualListSizeField;
        static FlickerFreeListView()
        {
            _internalVirtualListSizeField = typeof(ListView).GetField("virtualListSize", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance);
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);
        private IntPtr SendMessage(int msg, int wparam, int lparam)
        {
            return SendMessage(new HandleRef(this, this.Handle), msg, wparam, lparam);
        }
        public void SetVirtualListSize(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("ListViewVirtualListSizeInvalidArgument");
            }
            _internalVirtualListSizeField.SetValue(this, size);
            if ((base.IsHandleCreated && this.VirtualMode) && !base.DesignMode)
            {
                SendMessage(0x102f, size, 2);
            }
        }
