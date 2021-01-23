    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            TableCell cell = (TableCell)item["YourColumnName"];
            cell.BackColor = System.Drawing.Color.Yellow;
        }
    }
