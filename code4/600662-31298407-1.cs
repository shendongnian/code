    private bool itemInserted = false;
    
    protected void rgItems_InsertCommand(object sender, GridCommandEventArgs e)
    {
        itemInserted = true;
    }
    
    protected void rgItems_PreRender(object sender, EventArgs e)
    {
        if (itemInserted)
        {
            // Select the record and set the page
            int LastItem = 0; // Put code to get last inserted item here
            int Pagecount = rgItems.MasterTableView.PageCount;
            int i = 0;
            GridDataItem GDI = null;
            while (i < Pagecount)
            {
                rgItems.CurrentPageIndex = i;
                rgItems.Rebind();
                GDI = rgItems.MasterTableView.FindItemByKeyValue("IntItemId", LastItem);
                if (GDI != null) break; // IMPORTANT: Breaking here if the item is found stops you on the page the item is on
                i++;
            }
            if (GDI != null) GDI.Selected = true; // Optional: Select the item
            itemInserted = false;
        }
    }
