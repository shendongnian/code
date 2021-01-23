        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            var result = new List<IntPtr>();
            var listHandle = GCHandle.Alloc(result);
            try
            {
                var childProc = new User32.EnumWindowsProc(EnumWindow);
                User32.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }
        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            var gch = GCHandle.FromIntPtr(pointer);
            var list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            // Modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowsProc callback, IntPtr i);
        // sample usage:
        public void findWindowUser32()
        {
            foreach (IntPtr child in GetChildWindows(User32.FindWindow(null, "Untitled - Notepad")))
            {
                StringBuilder sb = new StringBuilder(100);
                User32.GetClassName(child, sb, sb.Capacity);
                if (sb.ToString() == "Edit")
                {
                    uint wparam = 0 << 29 | 0;
                    User32.PostMessage(child, WindowsConstants.WM_KEYDOWN, (IntPtr)Keys.H, (IntPtr)wparam);
                }
            }
        }
        
