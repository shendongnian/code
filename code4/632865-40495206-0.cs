    public override void ViewDidLoad()
    {
        base.ViewDidLoad();    
        NSNotificationCenter.DefaultCenter.AddObserver(new NSString("RowSelected"), RowSelected);
    }
    
    void RowSelected(NSNotification notification) 
    {
        var indexPath = notification.Object as NSIndexPath;
        // Do Something
    }
