    if (Properties.Settings.Default.CallUpgrade)
    {
        Properties.Settings.Default.Upgrade();
        Properties.Settings.Default.CallUpgrade = false;
        Properties.Settings.Default.Save();
    }
