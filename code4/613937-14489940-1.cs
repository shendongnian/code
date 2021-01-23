    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        Config.RegionChanged -= Config_RegionChanged;
        Config.RegionChanged += Config_RegionChanged;
    
        // do whatever else you need to do (initial data load)
                
        base.OnNavigatedTo(e);
    }
    
    async void Config_RegionChanged()
    {
        bLoaded = false;
        this.GoHome(this, new RoutedEventArgs());
    }
