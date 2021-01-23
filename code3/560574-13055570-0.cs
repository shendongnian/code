    SettingsPane.GetForCurrentView().CommandsRequested += SettingsCommandsRequested;
    private void SettingsCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
    {
        var privacyStatement = new SettingsCommand("privacy", "Privacy Statement", x => Launcher.LaunchUriAsync(
				new Uri("http://some-url.com")));
        args.Request.ApplicationCommands.Clear();
        args.Request.ApplicationCommands.Add(privacyStatement);
    }
