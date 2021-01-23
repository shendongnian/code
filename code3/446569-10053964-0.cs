    protected override void WndProc(ref Message m)
    {
        // Do not allow this window to become active - it should be "transparent" 
        // to mouse clicks i.e. Mouse clicks pass through this window
        if ( m.Msg == Win32Constants.WM_NCHITTEST )
        {
            m.Result = new IntPtr( Win32Constants.HTTRANSPARENT );
            return;
        }
    
        base.WndProc( ref m ) ;
    }
