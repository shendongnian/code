    protected void RepeaterPoll_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            dynamic item = e.Item.DataItem;
            RadioButtonList list = (RadioButtonList)e.Item.FindControl("rblItemPoll");
            list.DataValueField = "PollItemId";
            list.DataTextField = "PollItemDescription";
            list.DataSource = item.PollItems;
            list.DataBind();
        }
    }
