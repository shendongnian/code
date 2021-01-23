    public class FormEx : System.Windows.Forms.Form
    {
        // ...snip constructors and such          
        protected override void WndProc(ref Message m)
        {
        	switch (m.Msg)
        	{
                case NativeMethods.WM_WINDOWPOSCHANGING:
                    this.WmWindowPosChanging(m);
                    return;
                // ...snip
        	}
        
        	base.WndProc(m);
        }
    
        private void WmWindowPosChanging(ref Message m)
        {
        	// Extract the WINDOWPOS structure corresponding to this message
        	NativeMethods.WINDOWPOS wndPos = NativeMethods.WINDOWPOS.FromMessage(m);
        
        	// Determine if the size is changing (absence of SWP_NOSIZE flag)
        	if (!((wndPos.flags & NativeMethods.SetWindowPosFlags.SWP_NOSIZE) == NativeMethods.SetWindowPosFlags.SWP_NOSIZE))
        	{
        		// Raise the LowLevelSizeChanging event
        		SizeChangingEventArgs e = new SizeChangingEventArgs(this.Size, new Size(wndPos.cx, wndPos.cy));
        		this.OnLowLevelSizeChanging(e);
        
        		// Determine if the user canceled the size changing event
        		if (e.Cancel)
        		{
        			// If so, add the SWP_NOSIZE flag
        			wndPos.flags = wndPos.flags | NativeMethods.SetWindowPosFlags.SWP_NOSIZE;
        			wndPos.UpdateMessage(m);
        		}
        	}
        
        	// Determine if the position is changing (absence of SWP_NOMOVE flag)
        	if (!((wndPos.flags & NativeMethods.SetWindowPosFlags.SWP_NOMOVE) == NativeMethods.SetWindowPosFlags.SWP_NOMOVE))
        	{
        		// Raise the LowLevelPositionChanging event
        		PositionChangingEventArgs e = new PositionChangingEventArgs(this.Location, new Point(wndPos.x, wndPos.y));
        		this.OnLowLevelPositionChanging(e);
        
        		// Determine if the user canceled the position changing event
        		if (e.Cancel)
        		{
        			// If so, add the SWP_NOMOVE flag
        			wndPos.flags = wndPos.flags | NativeMethods.SetWindowPosFlags.SWP_NOMOVE;
        			wndPos.UpdateMessage(m);
        		}
        	}
        
        	base.WndProc(m);
        }
        // ...snip event infrastructure
    }
