    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
            if (indexPath.Row % 2 == 0) {
                    ContentView.BackgroundColor = UIColor.DarkGray;
            } else {
                    ContentView.BackgroundColor = UIColor.DarkTextColor;
            }
    }
