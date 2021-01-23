    // model for the settings
    class SettingsManager
    {
        public event EventHandler SettingsChanged;
        public async void ResetSettings()
        {
            await Windows.Storage.ApplicationData.Current.ClearAsync
                  (Windows.Storage.ApplicationDataLocality.Local);
            // initialize all values to default values;
            this._intializeValues();
            if (this.SettingsChanged != null)
                this.SettingsChanged(this, EventArgs.Empty);
        }
    }
