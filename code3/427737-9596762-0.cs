        class TableDelegate : UITableViewDelegate
    		{
    			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
    			{
    				this.YourNavigationController.PushViewController(yourViewController,true);
    			}
    }
