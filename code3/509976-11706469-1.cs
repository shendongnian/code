    protected void dl_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var myDropDownList = e.Item.FindControl("YourDropDownListID") as DropDownList;
            myDropDownList.DataSource = GetDDLDataSource();
            myDropDownList.DataBind();
        }
    }
