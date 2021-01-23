        var elSession = new EventLogSession("computername", "domain", "username", password, SessionAuthentication.Default);
        var elConfig = new EventLogConfiguration("Microsoft-Windows-Wordpad/Admin", elSession);
        if (!elConfig.IsEnabled)
        {
            elConfig.IsEnabled = true;
            elConfig.SaveChanges();
        }
