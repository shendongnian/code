    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings {
        
        public Settings() {
            this.SettingsLoaded += OnSettingsLoadedEvent;
        }
        private void OnSettingsLoadedEvent(object sender, SettingsLoadedEventArgs settingsLoadedEventArgs)
        {
            if (SomeNumParam >= 100)
            {
                const string msg = "SomeNumParam is invalid! Value must be between 0 and 100";
                Console.WriteLine(msg);
                throw new ArgumentOutOfRangeException(msg);
            }
        }
    }
