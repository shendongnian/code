    [DllImport("user32.dll")]
    static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    
    [DllImport("user32.dll")]
    static extern bool DeleteMenu(IntPtr hMenu, uint uPosition, uint uFlags);
    
    
    const uint SC_CLOSE = 0xF060;
    const uint MF_BYCOMMAND = 0x00000000;
    
    Process[] processes = Process.GetProcessesByName("Notepad");
    foreach (Process p in processes)
    {
    	IntPtr pFoundWindow = p.MainWindowHandle;
    
    	IntPtr nSysMenu = GetSystemMenu(pFoundWindow, false);
    	if (nSysMenu != IntPtr.Zero)
    	{
    		if (DeleteMenu(nSysMenu, SC_CLOSE, MF_BYCOMMAND))
    		{
    			//Done!
    		}
    	}
    }
