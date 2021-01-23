    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.EditCommandName)
        {
            RadGrid1.MasterTableView.ClearEditItems();
        }
    }
