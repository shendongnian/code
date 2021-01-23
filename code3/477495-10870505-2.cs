    [DllImport("user32.dll",
               CharSet=CharSet.Auto,
               CallingConvention=CallingConvention.StdCall)]
    private static extern void mouse_event(long dwFlags,
                                          long dx,
                                          long dy,
                                          long cButtons,
                                          long dwExtraInfo);
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    public void Click(Point pt)
    {
        Cursor.Position = pt;
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, pt.X, pt.Y, 0, 0);
    }
