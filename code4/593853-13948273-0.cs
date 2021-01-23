    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hwnd, ref Rectangle rectangle);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern bool PostMessage(IntPtr hWnd, uint msg, int WPARAM, int LPARAM);
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    
    public const uint WM_SYSCOMMAND = 0x0112;
    public const int SC_NEXTWINDOW = 0xF040;
    
    Public void resisezeWindow(String procesname, int Width, int Height)
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
                    	proc.Refresh();
    		}
    	}
    }
