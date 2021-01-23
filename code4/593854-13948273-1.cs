    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hwnd, ref Rectangle rectangle);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern bool PostMessage(IntPtr hWnd, uint msg, int WPARAM, int LPARAM);
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int, Y, int cx, int cy, uint uFlags);
    
    public const uint WM_SYSCOMMAND = 0x0112;
    public const int SC_NEXTWINDOW = 0xF040;
    public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    public const UInt32 TOPMOST_FLAGS = 0x0002 | 0x0001;
    
    Public void resisezeWindow(String procesname, int Width, int Height, Boolean bringtofront)
    {
    	foreach (Process proc in Process.GetProcesses())
    	{
    		IntPtr id = proc.MainWindowHandle;
    		Rectangle rect = new Rectangle();
    		GetWindowRect(id, ref rect);
    		if (proc.MainWindowTitle.Contains(procesname))
    		{
    			PostMessage(proc.Handle, WM_SYSCOMMAND, SC_NEXTWINDOW, 0);
                    	MoveWindow(id, 0, 0, Width, Height, true);
                        if(bringtofront) SetWindowPos(id, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
                    	proc.Refresh();
    		}
    	}
    }
