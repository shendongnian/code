    private Core()
    {
        this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
            new Action(delegate 
            { 
                SystemManager.EventAggregator.GetEvent<StartProgressWindow>().Publish(null);
            }));
        this.InitializeCore();
    } 
