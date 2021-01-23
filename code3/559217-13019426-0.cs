    public ManagedWindow ConvertToManaged(IntPtr hWnd)
    {
       return new ManagedWindow(hWnd);
    }
    
        public class ManagedWindow : IWin32Window
        {
            IntPtr _handle;
            public IntPtr Handle
            {
                get { return _handle; }
            }
    
            public ManagedWindow(IntPtr handle)
            {
                _handle = handle;
            }
        }
