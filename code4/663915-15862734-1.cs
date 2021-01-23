	// Code for allowing clicking through of the form
	protected override void WndProc(ref Message m)
	{
		const uint WM_NCHITTEST = 0x84;
		
		const int HTTRANSPARENT = -1;
		const int HTCLIENT      = 1;
		const int HTCAPTION     = 2;
		// ... or define an enum with all the values
		
		if (m.Msg == WM_NCHITTEST)
		{
			// If it's the message we want, handle it.
			if (penMode)
			{
				// If we're drawing, we want to see mouse events like normal.
				m.Result = new IntPtr(HTCLIENT);
			}
			else
			{
				// Otherwise, we want to pass mouse events on to the desktop,
				// as if we were not even here.
				m.Result = new IntPtr(HTTRANSPARENT);
			}
			return;  // bail out because we've handled the message
		}
		
		// Otherwise, call the base class implementation for default processing.
		base.WndProc(ref m);
	}
	
