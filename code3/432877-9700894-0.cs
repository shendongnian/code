    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        // replace with your logic
        String newOrder = "Column1";
        e.SortExpression = newOrder;
        e.SortDirection = "DESC";
    }
