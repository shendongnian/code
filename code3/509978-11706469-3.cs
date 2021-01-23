    protected void dl_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var myDropDownList = e.Item.FindControl("YourDropDownListID") as DropDownList;
            int currentItemID = int.Parse(this.dl.DataKeys[e.Item.ItemIndex].ToString());
            myDropDownList.DataSource = GetDDLDataSource(currentItemID);
            myDropDownList.DataBind();
        }
    }
