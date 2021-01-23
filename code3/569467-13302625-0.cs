    //using Windows.UI.ApplicationSettings;
    //using System;
    // You can put this event handler somewhere in a main class that runs your app.
    // I put it in may main view model.
    SettingsPane.GetForCurrentView().CommandsRequested += ShowPrivacyPolicy;
    
    // Method to add the privacy policy to the settings charm
    private void ShowPrivacyPolicy(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
    {
        SettingsCommand privacyPolicyCommand = new SettingsCommand("privacyPolicy","Privacy Policy", (uiCommand) => { LaunchPrivacyPolicyUrl(); });
        args.Request.ApplicationCommands.Add(privacyPolicyCommand);
    }
    
    // Method to launch the url of the privacy policy
    async void LaunchPrivacyPolicyUrl()
    {
        Uri privacyPolicyUrl = new Uri("http://www.yoursite.com/privacypolicy");
        var result = await Windows.System.Launcher.LaunchUriAsync(privacyPolicyUrl);
    }
