    private void Page_Load(object sender, System.EventArgs e)
    {
        SetControl("txtEdit","ASPxTextBox",1,0);
        SetControl("btnSave","ASPxButton",0,0);
    }
    
    private void SetControl(string controlId,string controlType, bool visible, bool enabled)
    { 
        foreach(Control control in Page.Controls)
        {
            if(controlType == "ASPxTextBox" && control is ASPxTextBox && control.Id == controlId)
            {
                var tb = ((ASPxTextBox)control);
    			tb.Visible = visible;
    			tb.Enabled = enabled;
    			break;
            }
    		if(controlType == "ASPxButton" && control is  ASPxButton && control.Id == controlId)
            {
                var bt = ((ASPxButton)control);
    			bt.Visible = visible;
    			bt.Enabled = enabled;
    			break;
            }
        }
    }
