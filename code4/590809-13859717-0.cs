    DispatcherTimer timer = new DispatcherTimer();
    timer.Interval = TimeSpan.FromSeconds(4);
    timer.Tick += delegate(object s, EventArgs args)
    {
        foreach (YourItem item in ViewModel.Items)
        {
            item.NotifyPropertyChanged("Modified");
        };
    }
    timer.Start();
