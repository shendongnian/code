    private void gvMyGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {                
        // Apply to header only.
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Text = "Column 1 Text";
            e.Row.Cells[1].Text = "Column 2 Text";
            e.Row.Cells[2].Text = "Column 3 Text";
        }
    }
