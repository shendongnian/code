    private void SetVisibility<T>(Control parent, bool isVisible)
    {
    	foreach (Control ctrl in parent.Controls)
    	{
    		if(ctrl is T)
    			ctrl.Visible = isVisible;
    		SetVisibility<T>(ctrl, isVisible);
    	}
    }
