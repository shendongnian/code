    public override void AwakeFromNib()
    {
        tableView.EnclosingScrollView.ContentView.PostsBoundsChangedNotifications = true;
        NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("boundsDidChangeNotification"), 
        NSView.BoundsChangedNotification, tableView.EnclosingScrollView.ContentView);
        base.AwakeFromNib();
    }
    [Export("boundsDidChangeNotification")]
    public void BoundsDidChangeNotification(NSObject o)
    {
        var notification = o as NSNotification;
        var view = notification.Object as NSView;
        var position = view.Bounds.Location;
        Console.WriteLine("Scroll position: " + position.ToString());
    } 
