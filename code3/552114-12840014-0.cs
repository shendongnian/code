    protected void gridOffers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TableCell cell = e.Row.Cells[0];
        e.Row.Cells.RemoveAt(0);
        //Move first to the end
        e.Row.Cells.Add(cell);
        cell = e.Row.Cells[0];
        e.Row.Cells.RemoveAt(0);
        //Move second to the end
        e.Row.Cells.Add(cell);
    }
