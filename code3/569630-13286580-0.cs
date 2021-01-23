    // used internally in native method
    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }
    
    
    // public accessible struct with extra fields 
    public struct RectEx
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    
        public dynamic Extra = "Extra";
    }
    
    
    public static class UnsafeNativeMethods
    {
        //used internally to populate RECT struct
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);
    
        //public safe method with exception handling and returns a RectEx
        public static RectEx GetWindowRectangle(HandleRef hWnd)
        {
            RECT r = new RECT();
    	    RectEx result = new RectEx();
    
            try
            {
                GetWindowRect(hWnd, r);
    	        result.Left = r.Left;
                result.Top = r.Top;
                result.Right = r.Right;
                result.Bottom = r.Bottom;
                // assign extra fields
            }
            catch(Exception ex)
            {
                // handle ex
            }
    	
    	return result;
        }
    }
