    [DllImport("user32.dll")]
    Public static extern int SendMessage(int hWnd,uint Msg,int wParam,int lParam);
    public const int WM_SYSCOMMAND = 0x0112;
    public const int SC_CLOSE = 0xF060;
    IntPtr window = FindWindow(null, "Location Browser Error");
    if (window != IntPtr.Zero)
    {
       Console.WriteLine("Window found, closing...");
       SendMessage((int) window, WM_SYSCOMMAND, SC_CLOSE, 0);  
    }
    
