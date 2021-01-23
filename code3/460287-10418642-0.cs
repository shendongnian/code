    if (Properties.Settings.Default.settingsUpgrade)
    {
        Object PrevVersion = Properties.Settings.Default.GetPreviousVersion("tooltipDisplay");
        if (PrevVersion != null)
        {
            WhatsNew WhatsNew = new WhatsNew();
            WhatsNew.Show();
            WhatsNew.BringToFront();
    
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.settingsUpgrade = false;
            Properties.Settings.Default.Save();
        }
    }
