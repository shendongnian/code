    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    
    // 0x0008 is the MOD_WIN Keys
    
    public static void RegisterKeys()
    {
    	RegisterHotKey((IntPtr)this.Handle, 1, 0x0008, 0x57);
    }
    
    protected override void WndProc(ref Message m)
    {
    	base.WndProc(ref m);
    
    	if (m.Msg == 0x0312)
    		this.Visible = !this.Visible;
    }
