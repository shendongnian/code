    private void InitializePhoneApplication()
    {
        if (phoneApplicationInitialized)
            return;
        RootFrame = new PhoneApplicationFrame { Style = Resources["myPhoneApplicationFrameStyle"] as Style };
        RootFrame.Navigated += CompleteInitializePhoneApplication;
        RootFrame.NavigationFailed += RootFrame_NavigationFailed;
        // Ensure we don't initialize again
        phoneApplicationInitialized = true;
    }
