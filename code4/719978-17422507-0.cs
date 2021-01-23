    private void Page_Load(object sender, System.EventArgs e)
    {
        SetControl("txtEdit","TextBox",1,0);
        SetControl("btnSave","Button",0,0);
    }
    
    private void SetControl(string controlId,string controlType, bool visible, bool enabled)
    { 
        foreach(Control control in Page.Controls)
        {
            if(controlType == "TextBox" && control is TextBox && control.Id == controlId)
            {
                var tb = ((TextBox)control);
    			tb.Visible = visible;
    			tb.Enabled = enabled;
    			break;
            }
    		if(controlType == "Button" && control is  Button && control.Id == controlId)
            {
                var bt = ((Button)control);
    			bt.Visible = visible;
    			bt.Enabled = enabled;
    			break;
            }
        }
    }
