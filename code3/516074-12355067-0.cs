    private void Application_Launching(object sender, LaunchingEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("App Launching");
    }
    private void Application_Activated(object sender, ActivatedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("App Activated");
    }
    private void Application_Deactivated(object sender, DeactivatedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("App Deactived");
    }
    private void Application_Closing(object sender, ClosingEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("App Closing");
    }
