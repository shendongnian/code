            private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
           var privacy = new SettingsCommand("PrivacyPolicy", "PrivacyPolicy", (handler) =>
                {
                    var settings = new SettingsFlyout();
                    settings.Content = new PrivacyUserControl();
                    //settings.HeaderBrush = new SolidColorBrush(_background);
                    //settings.Background = new SolidColorBrush(_background);
                    settings.HeaderBrush = _Hbackground;
                    settings.Background = _background;
                    settings.HeaderText = "Privacy Policy";
                    settings.IsOpen = true;
                });
            args.Request.ApplicationCommands.Add(privacy);
            UICommandInvokedHandler handler1 = new UICommandInvokedHandler(onSettingsCommand);
               //  throw new NotImplementedException();
        }
     void onSettingsCommand(IUICommand command)
        {
            SettingsCommand settingsCommand = (SettingsCommand)command;
            ((Frame)Window.Current.Content).Navigate(typeof(HelpPage), "");
        }
