    protected override void WndProc(ref Message m)
    {
    	// 0x115 is WM_VSCROLL
    	if( m.Msg == 0x115 )
    	{
    		// - Handle scrolling as desired (turn off AutoScroll)
    	}
    
    	base.WndProc(ref m);
    }
