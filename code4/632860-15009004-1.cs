    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
        new UIAlertView("Row Selected", tableItems[indexPath.Row], null, "OK", null).Show();
        tableView.DeselectRow(indexPath, true);
        controller.DoWhatYouNeedWithIt ();
    }
