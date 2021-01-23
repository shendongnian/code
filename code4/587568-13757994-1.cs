    protected override void Configure()
    {
        container = new WinRTContainer();
        container.RegisterWinRTServices();
        ConventionManager.AddElementConvention<Grid>(Grid.BackgroundProperty, "Background", "Loaded");
    }
