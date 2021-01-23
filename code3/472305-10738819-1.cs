    if (Properties.Settings.Default.SettingsUpgradeRequired)
    {
        Properties.Settings.Default.Upgrade();
        Properties.Settings.SettingsUpgradeRequired = false;
        Properties.Settings.Default.Save();
    }
