    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool PostMessage(int hWnd, uint Msg, int wParam, int lParam);
    // int MouseX
    // int MouseY
    // public static readonly uint WM_LBUTTONUP = 0x202;
    // public static readonly uint WM_LBUTTONDOWN = 0x201;
    int lparam = MouseX & 0xFFFF | (MouseY & 0xFFFF) << 16;
    int wparam = 0;
    PostMessage(windowHandle, WM_LBUTTONDOWN, wparam, lparam);      
    Thread.Sleep(10);  
    PostMessage(windowHandle, WM_LBUTTONUP, wparam, lparam);
