    private void Application_Launching(object sender, LaunchingEventArgs e)
    {
        DetectUserTheme();
    }
    private void DetectUserTheme()
    {
        if(LightThemeUsed)
        {
            // Adapt your icons, background for the light theme.
            return;
        }
        // Adapt your icons, background for the dark theme. 
    }
    
