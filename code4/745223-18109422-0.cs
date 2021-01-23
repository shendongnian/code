        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
        public static extern uint GetClassName(IntPtr handle, StringBuilder name, int maxLength);
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
        private static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
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
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }
        public static IntPtr GetWindowByClass(IntPtr mainWindow, string name)
        {
            List<IntPtr> windows = GetChildWindows(mainWindow);
            foreach (IntPtr window in windows)
            {
                StringBuilder response = new StringBuilder();
                response.Capacity = 500;
                if (GetClassName(window, response, response.Capacity) > 0)
                    if (response.ToString() == name)
                        return window;
            }
            return IntPtr.Zero;
        }
