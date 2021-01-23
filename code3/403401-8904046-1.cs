    private void gvMyGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {                
        // Apply to header only.
        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (Cell cell in e.Row.Cells)
            {
                if (cell.Text == "FName")
                {
                    cell.Text = "First Name";
                }
                else if (cell.Text == "LName")
                {
                    cell.Text = "Last Name";
                }
                else if (cell.Text == "Etc")
                {
                    cell.Text = "Et cetera";
                }
            }
        }
    }
