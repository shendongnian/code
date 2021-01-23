    public override void AwakeFromNib()
    {
        tableView.EnclosingScrollView.ContentView.PostsBoundsChangedNotifications = true;
        NSNotificationCenter.DefaultCenter.AddObserver(NSView.BoundsChangedNotification, BoundsDidChangeNotification, tableView.EnclosingScrollView.ContentView);
    
        base.AwakeFromNib();
    }
    
    public void BoundsDidChangeNotification(NSNotification notification)
    {
        var view = notification.Object as NSView;
        var position = view.Bounds.Location;
        Console.WriteLine("Scroll position: " + position.ToString());
    } 
