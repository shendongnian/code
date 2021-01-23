    public delegate void ActionCallback();
    
    public static void SafeInvoke(this Form form, ActionCallback action)
    {
    	if (form.InvokeRequired)
    		form.Invoke(action);
    	else
    		action();
    }
    
    public static void SafeSetText(this Control ctl)
    {
    	var form = ctl.FindForm();
    	if (form == null) return; // or do something else
    
    	form.SafeInvoke(() =>
    		{
    			// Do stuff
    		});
    }
