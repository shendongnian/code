    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DropDownList DropDownID = (DropDownList)e.Item.FindControl("DropDownID");
            int ItemNo = ((YourClassName)e.Item.DataItem).Yourproperty;
            DropDownID.Items[ItemNo].Selected = true;
        }
    }
