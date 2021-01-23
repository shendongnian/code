    using System.Runtime.InteropServices;
    using System.Security;
    
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeMessage
    {
        public IntPtr handle;
        public uint msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public System.Drawing.Point p;
    }
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool PeekMessage(out NativeMessage message,
        IntPtr handle, uint filterMin, uint filterMax, uint flags);
    private const UInt32 WM_MOUSEFIRST = 0x0200;
    private const UInt32 WM_MOUSELAST = 0x020D;
    public const int PM_REMOVE = 0x0001;
    
    // Flush all pending mouse events.
    private void FlushMouseMessages()
    {
        NativeMessage msg;
        // Repeat until PeekMessage returns false.
        while (PeekMessage(out msg, IntPtr.Zero,
            WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE))
            ;
    }
