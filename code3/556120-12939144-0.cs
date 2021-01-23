    void onCommandsRequested(SettingsPane settingsPane, SettingsPaneCommandsRequestedEventArgs eventArgs)
            {
                UICommandInvokedHandler handler = new UICommandInvokedHandler(onSettingsCommand);
    
                SettingsCommand generalCommand = new SettingsCommand("DefaultsId", "Defaults", handler);
                eventArgs.Request.ApplicationCommands.Add(generalCommand);
            }
