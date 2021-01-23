    public class MyTableViewSource : UITableViewSource {
        UITableViewController ctrl;
        public MyTableViewSource (UITableViewController c)
        {
            ctrl = c;
        }
        public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow (indexPath, true);
            var home = new UIViewController ("YouNibName", null); // default bundle
            ctrl.PresentModalViewController (home, true);
        }
    }
