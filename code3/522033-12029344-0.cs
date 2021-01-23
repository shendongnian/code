    Item NewItem = new Item();
            foreach (GridViewRow PendingItemUnderControl in GridViewPendingList.Rows)
            {
                NewItem.Paramater = PendingItemUnderControl.Cells[0].Text.ToLower();
                NewItem.Type = (String)Session["BrowseType"];
                lstNewItems.Add(NewItem);
            }
           ControlFiles_Result = Client.FilesToControl(lstNewItems);
