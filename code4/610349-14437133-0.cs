    public static void UpgradeUserSettings()
    {
      if (Settings.Default.upgradeRequired)
      {
        Settings.Default.Upgrade();
        Settings.Default.upgradeRequired = false;
        Settings.Default.Save();
      }
    } 
