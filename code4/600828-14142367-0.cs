        private const int WS_EX_NOACTIVATE = 0x08000000;
		protected override CreateParams CreateParams
		{
		    get
		    {
		        CreateParams createParams = base.CreateParams;
		        createParams.ExStyle = createParams.ExStyle | WS_EX_NOACTIVATE;
		        return createParams;
		    }
		}
		private const int WM_MOUSEACTIVATE = 0x0021;
		private const int MA_NOACTIVATE = 0x0003;
		protected override void WndProc(ref Message m)
		{
		    //If we're being activated because the mouse clicked on us...
            if (m.Msg == WM_MOUSEACTIVATE)
		    {
		        //Then refuse to be activated, but allow the click event to pass through (don't use MA_NOACTIVATEEAT)
		        m.Result = (IntPtr)MA_NOACTIVATE;
		    }
		    else
		        base.WndProc(ref m);
		}
