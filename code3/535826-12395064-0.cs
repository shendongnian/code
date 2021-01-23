    string rawConnString = Properties.Settings.Default.ConnectionString;
    
    string finalConnString = rawConnString
                                .Replace("<<DATA_SOURCE>>", server)
                                .Replace("<<INITIAL_CATALOG>>", "tempdb");
