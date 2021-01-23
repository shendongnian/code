    void OnItemClick(object sender, ItemClickEventArgs e)
    {
        var item = (SampleDataItem)e.ClickedItem;
        // ignore one specific item - here we use UniqueId, but it could be
        // any attribute...
        if (string.Compare(item.UniqueId, "Group-1-Item-1") == 0)
            return;
        // normal processing here...
        ...
     }
