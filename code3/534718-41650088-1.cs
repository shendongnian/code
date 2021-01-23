    protected void myGridView_RowDataBound(object o, GridViewRowEventArgs e)
    {
            // Set the alignment of cells containing numeric data.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            }
    }
