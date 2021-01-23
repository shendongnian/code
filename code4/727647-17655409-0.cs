    public override void AwakeFromNib()
    {
        tableView.Delegate = new MyDelegate();
    }
    private class MyDelegate : NSTableViewDelegate
    {
        public override void ColumnDidMove(NSNotification notification)
        {
             Console.WriteLine("column did move");
        }
    }
