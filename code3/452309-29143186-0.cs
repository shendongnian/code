    protected void ItemDataBound(object sender, EventArgs e)
    {
        Button myButton = (Button)e.Item.FindControl("myButton");
        if (myButton != null) 
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(myButton);
    }
