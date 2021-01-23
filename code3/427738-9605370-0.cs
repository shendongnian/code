    public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
    			{
                                    
    				var DetailViewController = new DetailViewController ();
    				// Pass the selected object to the new view controller.
    				controller.NavigationController.PushViewController(DetailViewController, true);
    			} 
