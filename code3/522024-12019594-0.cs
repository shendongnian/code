    [DllImport("user32.dll")]
    static extern IntPtr GetActiveWindow();
    [DllImport("user32.dll")]
    public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
            
    public const int WM_SYSCOMMAND = 0x0112;
    public const int SC_CLOSE = 0xF060;
    // close the active window using API        
    private void FindAndCloseActiveWindow()
    {
     IntPtr handle=GetActiveWindow();
     SendMessage(handle, WM_SYSCOMMAND, SC_CLOSE, 0);
    }
