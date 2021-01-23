      public class TableSourceAnimales : UITableViewSource
      {
         public  event RowSelectedEventHandler RowSelectedEvent;
        public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			if (this.RowSelectedEvent != null) {
				RowSelectedEvent (indexPath);
			}
		}
      }
