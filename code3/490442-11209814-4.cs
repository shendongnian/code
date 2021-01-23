    private void Application_Launching(object sender, LaunchingEventArgs e)
    {
        _timer.Start();
        // Should probably have some logic to determine if they tombstoned the app
        // and did not actually leave the app, if so then save that time
    }
    
    private void Application_Activated(object sender, ActivatedEventArgs e)
    {
        _timer.Start();
        // Restore _spentTime
    }
    
    private void Application_Deactivated(object sender, DeactivatedEventArgs e)
    {
        _timer.Stop();
        // Store _spentTime
    }
    
    private void Application_Closing(object sender, ClosingEventArgs e)
    {
        // Save time, they're done!
    }
 
