    var timer = new System.Windows.Threading.DispatcherTimer();
    timer.Tick += Timer_Tick;
    timer.Interval = new TimeSpan(0,1,0);
    timer.Start();
    
    
    private void Timer_Tick(object sender, EventArgs e)
    {
        MyCollection = GetUpdatedCollectionData();
    }
