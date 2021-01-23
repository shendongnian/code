    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    public const int MOD_WIN = 0x00000008;
    public const int KEY_W = 0x00000057
    
    public static void RegisterKeys()
    {
    	RegisterHotKey((IntPtr)this.Handle, 1, MOD_WIN, KEY_W);
    }
    
    protected override void WndProc(ref Message m)
    {
    	base.WndProc(ref m);
    
    	if (m.Msg == 0x0312)
    		this.Visible = !this.Visible;
    }
