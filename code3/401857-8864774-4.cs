    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        // Make sure the splash screen is closed
        CloseSplash();
        base.OnClosing(e);
    } 
