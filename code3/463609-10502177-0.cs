    if (Settings.Default.IsUpgrade)
    {
      Settings.Default.Upgrade();
      Settings.Default.IsUpgrade = false;
      Settings.Default.Save();
    }
