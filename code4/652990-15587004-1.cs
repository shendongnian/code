    [DllImport("user32.dll")]
    static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
    public static void KeyDown(System.Windows.Forms.Keys key)
    {
          keybd_event((byte)key, 0x45, 0x0001 | 0, 0);
    }
    
    public static void KeyUp(System.Windows.Forms.Keys key)
    {
          keybd_event((byte)key, 0x45, 0x0001 | 0x0002, 0);
    }
