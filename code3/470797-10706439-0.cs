    public partial class TestController : UITableViewController
    	{
    		public TestController (IntPtr handle) : base (handle)
    		{
    			
    		}
    		
    		public override void ViewDidLoad ()
    		{
    			base.ViewDidLoad ();
    		}
    		
    		[Export("tableView:titleForHeaderInSection:")]
    		public string TitleForHeaderInSection(UITableView oTableView, int iSection)
    		{
    			return "TEST";
    		}
    	}
