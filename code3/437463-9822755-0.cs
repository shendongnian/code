    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            MyType myItem = (MyType)e.Item.DataItem;
            var dataId = myItem.DataId;
            // Do whatever you need here.
        }
    }
