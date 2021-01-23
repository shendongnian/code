    if (Properties.Settings.Default.FirstRun)
    {
        Properties.Settings.Default.FirstRun = false;
        if (myConditionIsTrue)
            Properties.Settings.Default.Environment = 3;
        Properties.Settings.Default.Save();
    }
