    protected void button_OnClick(object sender, EventArgs e)
    {
    	foreach (GridViewRow row in gvUserFiles.Rows)
    	{
    		CheckBox cb = (CheckBox)row.FindControl("chkSelect");
    
    		if (cb != null)
    		{
    			bool ckbChecked = Request.Form[cb.UniqueID] == "on";
    
    			if (ckbChecked)
    			{
    				//do stuff
    			}
    		}
    	}
    }
