    protected void CloseLinkClicked(Object sender, EventArgs e)
    {
        var closeLink = (Control) sender;
        GridViewRow row = (GridViewRow) closeLink.NamingContainer;
        string firstCellText = row.Cells[0].Text; // here we are
    }
