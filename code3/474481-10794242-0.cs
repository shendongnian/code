    public static int GetDataItemIndex(this GridViewRow row)
    {
        var gridView = (GridView)row.NamingContainer;
        return row.RowIndex + (gridView.PageIndex * gridView.PageSize);
    }
