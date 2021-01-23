    void OnItemClick(object sender, ItemClickEventArgs e)
    {
        // Navigate to the appropriate destination page, configuring the new page
        // by passing required information as a navigation parameter
        var item = (SampleDataItem)e.ClickedItem;
        var itemId = item.UniqueId;
        // ignore one specific item - here we use UniqueId, but it could be
        // any attribute...
        if (string.Compare(item.UniqueId, "Group-1-Item-1") == 0)
            return;
        // normal processing here...
        ...
     }
