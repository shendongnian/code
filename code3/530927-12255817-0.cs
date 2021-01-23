    protected override void WndProc(ref Message m) 
    {
    	if (m.Msg == /*WM_SIZE*/ 0x0005)
    	{
    		if(this.WindowState == FormWindowState.Minimized) 
    		{
    			// do something here
    		}
    	}
    	
    	base.WndProc(ref m);
    }
