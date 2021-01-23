    protected void dlconfigureItem_ItemDataBound(object sender, DataListItemEventArgs e) 
    {
        DropDownList ddlitem = e.Item.FindControl("ddlitem") as DropDownList;
        if (ddlitem != null)
        {
            // ...
        }
    }
