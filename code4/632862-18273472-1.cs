    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
        selectedItem = tableItems[indexPath.Row];
        ItemSelected(this, EventArgs.Empty);
    }
