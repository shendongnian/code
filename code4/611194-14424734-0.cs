    private void MakeTransparentControls(Control parent)
    {
    	if (parent.Controls != null && parent.Controls.Count > 0)
    	{
    		foreach (Control control in parent.Controls)
    		{
    			if ((control is PictureBox) || (control is Label) || (control is GroupBox) || (control is CheckBox))
    				control.BackColor = Color.Transparent;
    
    			if (control.Controls != null && control.Controls.Count > 0)
    				MakeTransparentControls(control);
    		}
    	}
    }
