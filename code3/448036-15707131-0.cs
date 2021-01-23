    // I changed a bit of the method signature, but that doesn't really matter
    [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
    static extern void mouse_event(MouseEventFlags flags, uint dx, uint dy, uint delta, IntPtr extraInfo);
    [Flags]
    enum MouseEventFlags : uint
    {
        Absolute = 0x8000,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        Move = 0x0001,
        RightDown = 0x0008,
        RightUp = 0x0010,
        Wheel = 0x0800,
        XDown = 0x0080,
        XUp = 0x0100,
        HWheel = 0x1000,
    }
    
    public void LeftMouseDown()
    {
        // Simulate left down, notice that RELATIVE movement is 0
        mouse_event(MouseEventFlags.LeftDown, 0, 0, 0, IntPtr.Zero);
    }
    
    public void LeftMouseUp()
    {
        // Simulate left up, notice that RELATIVE movement is 0 too
        mouse_event(MouseEventFlags.LeftUp, 0, 0, 0, IntPtr.Zero);
    }
