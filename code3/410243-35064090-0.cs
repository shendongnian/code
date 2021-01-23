    protected override void OnKeyDown(KeyEventArgs e)
    {
    	if (e.KeyCode == Keys.Tab)
    	{
    		HandleFocus(this, ActiveControl);
    	}
    	else
    	{
    		base.OnKeyDown(e);
    	}
    }
    
    internal static void HandleFocus(Control parent, Control current)
    {
    	Keyboard keyboard = new Keyboard();
    	//Move to the first control that can receive focus, taking into account
    	//the possibility that the user pressed <Shift>+<Tab>, in which case we
    	//need to start at the end and work backwards.
    	System.Windows.Forms.Control ctl = parent.GetNextControl(current, !keyboard.ShiftKeyDown);
    	while (null != ctl)
    	{
    		if (ctl.Enabled && ctl.CanSelect)
    		{
    			ctl.Focus();
    			break;
    		}
    		else
    		{
    			ctl = parent.GetNextControl(ctl, !keyboard.ShiftKeyDown);
    		}
    	}
    }
