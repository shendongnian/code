        if (Properties.Settings.Default.SettingsUpgradeNeeded)
        {
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.SettingsUpgradeNeeded = false;
            Properties.Settings.Default.Save();
        }
  
