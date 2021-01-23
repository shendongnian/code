    protected void Application_Start()
    {
        // with your other startup registrations
        RavenConfig.Register();
    }
    protected void Application_End()
    {
        // for a clean shutdown
        RavenConfig.Cleanup();
    }
