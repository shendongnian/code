    protected override void Configure()
    {
        container = new WinRTContainer();
        container.RegisterWinRTServices();
    
        MessageBinder.SpecialValues.Add("$pointerpercentage", ctx =>
        {
            return 1.0f;
        });
    }
