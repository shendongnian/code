    protected void hdnButton_Click(object sender, EventArgs e)
    {
        String[] Value = hdnCurrent.Value.Split('|');
        
        if (Value[1] == "true")
        {
            //Do operations here when the check box is checked
        }
        else
        { 
            //Do operations here when the check box is unchecked
        }
        
        //Value[0] contains the id of the check box that is checked/unchecked.
    }
