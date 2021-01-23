    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool PeekMessage([In, Out] ref MSG msg, HandleRef hwnd, int msgMin, int msgMax, int remove);
    
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
    	public IntPtr hwnd;
    	public int message;
    	public IntPtr wParam;
    	public IntPtr lParam;
    	public int time;
    	public int pt_x;
    	public int pt_y;
    }
    
    private void RemovePendingMessages(Control c, int msgMin, int msgMax)
    {
    	if (!this.IsDisposed)
    	{
    		MSG msg = new MSG();
    		IntPtr handle = c.Handle;
    		while (PeekMessage(ref msg, new HandleRef(c, handle), msgMin, msgMax, 1))
    		{
    		}
    	}
    }
    
    private void SuppressKeyPress(Control c)
    {
    	this.RemovePendingMessages(c, 0x102, 0x102);
    	this.RemovePendingMessages(c, 0x106, 0x106);
    	this.RemovePendingMessages(c, 0x286, 0x286);
    }
    
    private void SuppressKeyUp(Control c)
    {
    	this.RemovePendingMessages(c, 0x101, 0x101);
    	this.RemovePendingMessages(c, 0x105, 0x105);
    }
    
    private void textBox2_KeyDown(object sender, KeyEventArgs e)
    {
    	if (e.KeyCode == Keys.H)
    	{
    		SuppressKeyPress(sender);		// will work
    		SuppressKeyUp(sender);			// won't work
    	}
    }
