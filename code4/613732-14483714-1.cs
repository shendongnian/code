    protected void User_Repeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = (RepeaterItem)e.Item;
        if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
        {
            DropDownList User_PL = (DropDownList)item.FindControl("User_PL");
            ... Set your value here -- consider adding a hidden element with the value you're trying to set it to and get the value the same was as we got the DropDownList
        }
    }
