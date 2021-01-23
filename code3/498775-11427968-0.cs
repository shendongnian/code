    protected void GridView1_SelectedIndexChanged(Object sender, EventArgs e)
    {
        var grid = (GridView)sender;
        foreach (GridViewRow row in grid.Rows)
        {
            var btn = (Button)grid.SelectedRow.FindControl("Button1");
            // Compare this row with the currently selected row using the SelectedRow property
            // SelectedRow might be nuull, but it would work anyway
            btn.Visible = row== grid.SelectedRow;
        }
    }
