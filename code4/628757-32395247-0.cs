    protected void ChatListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item is ListViewDataItem)
        {
             var yourLabel = e.Item.FindControl("Label1") as Label;
             // ...
        }
    }
