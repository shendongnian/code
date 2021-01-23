    public static IntPtr FindWindowByPartialCaption(String partialCaption)
        {
            var desktop = User32.GetDesktopWindow();
            var children = EnumerateWindows.GetChildWindows(desktop);
            foreach (var intPtr in children)
            {
                var current = GetText(intPtr);
                if (current.Contains(partialCaption))
                    return intPtr;
            }
            return IntPtr.Zero;
        }
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowProc lpEnumFunc, IntPtr lParam);
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            return GetChildWindows(parent, false);
        }
        public static List<IntPtr> GetChildWindows(IntPtr parent, bool reverse)
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
            if (reverse)
            {
                List<IntPtr> resultList = result.Reverse<IntPtr>().ToList();
                return resultList;
            } 
            else
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
    }
