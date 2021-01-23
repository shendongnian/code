    public T FindControl<T>(Control parent) where T : Control
    {
    	foreach (Control c in parent.Controls)
    	{
    		if (c is T)
    		{
    			return (T)c;
    		}
    		else if (c.Controls.Count > 0)
    		{
    			Control child = FindControl<T>(c);
    			if (child != null)
    				return (T)child;
    		}
    	}
    
    	return null;
    }
