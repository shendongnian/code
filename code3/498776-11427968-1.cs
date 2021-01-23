    protected void GridView1_SelectedIndexChanged(Object sender, EventArgs e)
    {
        var grid = (GridView)sender;
        foreach (GridViewRow row in grid.Rows)
        {
            var btn = (Button)row.FindControl("Button1");
            // Compare this row with the currently selected row using the SelectedRow property
            // SelectedRow might be null, the logic would work anyway
            btn.Visible = row == grid.SelectedRow;
        }
    }
