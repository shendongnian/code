    private void BindResourcesRepater()
    {
        // your existing code...
        int numberOfItems = ds.Tables[0].Rows.Count;
        lblCurrentVisibleItems.Text = GetCurrentVisibleItemsText(numberOfItems, objPds.PageSize, objPds.CurrentPageIndex);
    }
    private string GetCurrentVisibleItemsText(int numberOfItems, int pageSize, int currentPageIndex)
    {
        int startVisibleItems = currentPageIndex * pageSize + 1;
        int endVisibleItems = (currentPageIndex + 1) * pageSize;
        if(endVisibleItems > numberOfItems)
            endVisibleItems = numberOfItems;
        return string.Format("Displaying {0}-{1} of {2} items", startVisibleItems, endVisibleItems, numberOfItems);
    }
