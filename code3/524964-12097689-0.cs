    string dbLocation = Properties.Settings.Default.DatabaseLocation;
    if (string.IsNullOrWhiteSpace(dbLocation)
    {
        dbLocation = AskUserForLocation();
        Properties.Settings.Default.DatabaseLocation = dbLocation;
        Properties.Settings.Default.Save();
    }
    AppDomain.CurrentDomain.SetData("DataDirectory",dbLocation);
