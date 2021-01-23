    public static void UpgradeSettingsIfRequired()
    {
        string version = Assembly.GetEntryAssembly().GetName().Version.ToString();
        if (Settings.Default.CurrentVersion != version)
        {
            Settings.Default.Upgrade();
            Settings.Default.CurrentVersion = version;
            Settings.Default.Save();
        }
    }
