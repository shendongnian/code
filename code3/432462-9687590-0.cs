    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DropDownList DropDownID = (DropDownList)e.Item.FindControl("DropDownID");
            DropDownID.Items[1].Selected = true;
        }
    }
