    protected void ddlVendor_SelectedIndexChanged (object sender, EventArgs e)
    {
        MyFunction(sender);
    }
    
    protected void ddlInsertVendorName_SelectedIndexChanged (object sender, EventArgs e)
    {
        MyFunction(sender);
    }
    protected void MyFunction(Object sender)
    {
        DropDownList ddl = (DropDownList)sender //ddl will contain the ID etc...
        //shared logic here
        if(ddl.ID.equals("ddlVendor"))
        {
            //edit mode
        }
        else 
        {
            //insert mode
        }
    }
