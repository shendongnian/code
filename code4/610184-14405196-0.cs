    private ProximityDevice proximity = ProximityDevice.GetDefault();
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (proximity != null)
        {
            proximity.DeviceArrived += proximity_DeviceArrived;
        }   
        base.OnNavigatedTo(e);
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        if (proximity != null)
        {
            proximity.DeviceArrived -= proximity_DeviceArrived;
        }   
        base.OnNavigatedFrom(e);
    }
