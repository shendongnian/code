    public class MyTableViewDelegate : UITableViewDelegate {
        UITableView view;
        public MyTableViewDelegate (UITableView tv)
        {
            view = tv;
        }
        public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow (indexPath, true);
            var home = new UIViewController ("YouNibName", null); // default bundle
            view.PresentModalViewController (home, true);
        }
    }
