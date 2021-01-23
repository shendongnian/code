    foreach (GridViewRow PendingItemUnderControl in GridViewPendingList.Rows)
    {
        Item NewItem = new Item(); <------
        NewItem.Paramater = PendingItemUnderControl.Cells[0].Text.ToLower();
        NewItem.Type = (String)Session["BrowseType"];
        lstNewItems.Add(NewItem);
    }
