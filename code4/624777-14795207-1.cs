    public class TestProxy : NSObject
    {
        private NSObject realDelegate;
        public TestProxy(NSObject realDelegate)
        {
            this.realDelegate = realDelegate;
        }
        public override bool RespondsToSelector(MonoTouch.ObjCRuntime.Selector sel)
        {
            Console.WriteLine("Query : " + sel.Name);
            return this.realDelegate.RespondsToSelector(sel);
        }
        [Export("tableView:didSelectRowAtIndexPath:")]
        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // invoke method on realDelegate either by casting to the correct type or by using
            // reflection to find the method that matches the export and pass this method's arguments.
            // which way you implement depends on your needs and what you know about the delegate being
            // proxied - casting would be much faster than reflection.
        }
    }
