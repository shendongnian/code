		public override void WillDisplay (UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
		{
			if (indexPath.Row % 2 == 0) {
				cell.BackgroundColor = UIColor.White;
			} else {
				cell.BackgroundColor = UIColor.LightGray;
			}
		}
