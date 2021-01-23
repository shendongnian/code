    private void InitializePhoneApplication()
    {
    if (phoneApplicationInitialized)
        return;
 
    // Create the frame but don't set it as RootVisual yet; this allows the splash
    // screen to remain active until the application is ready to render.
    RootFrame = new TransitionFrame();
    RootFrame.Navigated += CompleteInitializePhoneApplication;
 
    // Handle navigation failures
    RootFrame.NavigationFailed += RootFrame_NavigationFailed;
 
    // Ensure we don't initialize again
    phoneApplicationInitialized = true;
    }
