    Protected void SetCheckBoxState( ControlCollection  controls)
    {
        Foreach (Control c in controls)
    	{
    		If (c is System.Web.UI.WebControls.CheckBox)//change to make it CheckBox
    		{
    			CheckBox cb = c as CheckBox;
    			cb.Checked = false; // or true what ever you need to do 
    		}
    		Else if (c.controls.Count > 0)
    		{
    			SetCheckBoxState(c.Controls)
    		}
    	}
    }
