    void rptrTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        {
            // Find the DropDownList in the repeater's ItemTemplate
            // so we can manipulate it.
            DropDownList ddlSelect =
                e.Item.FindControl("ddlSelect") as DropDownList;
            if (ddlSelect == null) return;
       
            DataTable dt = new DataTable();
            dt = Common.LoadExample();
        
            ddlSelect .DataSource = dt;
            ddlSelect .DataTextField = "Name";
            ddlSelect .DataValueField = "Name";
            ddlSelect .DataBind();
        }
    }
