    core.ResourceManager.Current.DefaultContext.QualifierValues.MapChanged 
            += async (s, m) =>
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    settingsLanguageLabel.Text = core.ResourceManager.Current.MainResourceMap.GetValue("Resources/SettingsLanguageLabel/Text").ValueAsString;
                    settingsRestartLabel.Text = core.ResourceManager.Current.MainResourceMap.GetValue("Resources/SettingsRestartLabel/Text").ValueAsString;
                });
            };
