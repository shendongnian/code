    private void InitializePhoneApplication()
    {
        if (phoneApplicationInitialized)
            return;
        // Instead of creating a PhoneApplicationFrame, use your own
        RootFrame = new YourSuperCoolFrame();
        RootFrame.Navigated += CompleteInitializePhoneApplication;
        ... // rest of the original code
    }
