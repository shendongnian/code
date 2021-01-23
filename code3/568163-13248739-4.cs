    <script language="javascript" type="text/javascript">
        var oldColour = null;
        function rowMouseover(o) {
            o.style.cursor = 'pointer';
            oldColour = o.style.backgroundColor;
            o.style.backgroundColor = '#dddddd';
        }
        function rowMouseout(o) {
            o.style.backgroundColor = oldColour;
        }
    </script>
    <asp:GridView ... OnRowCreated="grid_RowCreated" />
    protected void grid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] =
                Page.ClientScript.GetPostBackClientHyperlink(
                    this.grid, 
                    "Select$" + e.Row.RowIndex);
            e.Row.Attributes["onmouseover"] = "rowMouseover(this);";
            e.Row.Attributes["onmouseout"] = "rowMouseout(this);";
        }
    }
    protected override void Render(HtmlTextWriter writer)
    {
        for (int i = 0; i < grid.Rows.Count; i++)
            Page.ClientScript.RegisterForEventValidation(grid.UniqueID, "Select$" + i); 
        base.Render(writer);
    }
