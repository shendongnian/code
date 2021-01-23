     namespace yournamespace
     public delegate void RowSelectedEventHandler(MonoTouch.Foundation.NSIndexPath indexpath);
     public partial class yourclass : UIViewController
     {
     public override void ViewDidLoad ()
     {
       TableViewDataSource tablelist = new TableViewDataSource (yourlist);
       table.Source = tablelist;
       table.ReloadData ();
       table.RowSelectedEvent += tablelist_RowSelectedEvent;
     }
     public void tablelist_RowSelectedEvent (NSIndexPath indexpath)
	   {
            this.YourNavigationController.PushViewController(yourViewController,true);
          //or what you want to do
        }
     }
 
