    string strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
    if(!string.IsNullOrEmpty(Properties.Settings.Default.currentVersion) 
        && Properties.Settings.Default.currentVersion != strVersion)
    {
        WhatsNew WhatsNew = new WhatsNew();
        WhatsNew.Show();
        WhatsNew.BringToFront();
        Properties.Settings.Default.Upgrade();
        Properties.Settings.Default.currentVersion = strVersion;
        Properties.Settings.Default.Save();                
    }
