    private void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType != DataControlRowType.DataRow)
        return;
    
    foreach (TableCell cell in e.Row.Cells)
                cell.EnableViewState = false;
    
    e.Row.Cells[0].EnableViewState = true;
    e.Row.Cells[1].EnableViewState = true;
    }
