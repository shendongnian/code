        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            
            if (rootFrame == null)
            {
    #if DEBUG
                licenseInformation = CurrentAppSimulator.LicenseInformation;
    #else
                licenseInformation = CurrentApp.LicenseInformation;
    #endif
                // other init here...
            }
        }
