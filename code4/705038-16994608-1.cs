    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                ((DataControlFieldHeaderCell)cell).Scope = TableHeaderScope.NotSet;   
            }
        }
    }
