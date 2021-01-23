    <asp:GridView ... OnRowCreated="grid_RowCreated" />
    protected void grid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] =
                Page.ClientScript.GetPostBackClientHyperlink(
                    this.grid, 
                    "Select$" + e.Row.RowIndex);
        }
    }
    protected override void Render(HtmlTextWriter writer)
    {
        for (int i = 0; i < grid.Rows.Count; i++)
            Page.ClientScript.RegisterForEventValidation(grid.UniqueID, "Select$" + i); 
        base.Render(writer);
    }
