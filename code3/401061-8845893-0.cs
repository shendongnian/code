    foreach (GridViewRow row in TaskGridView.Rows)
    {
        if ((row.RowState & DataControlRowState.Alternate) == DataControlRowState.Alternate &&
            row.RowType == DataControlRowType.DataRow)
        {
    
           Response.Write("," +row.Cells[1].Text);// id
    
        }
    }
