    string ConnectionString = string.Empty;
    // get the entry from the config file
    var entry = ConfigurationManager.ConnectionStrings["MyConncetionString"];
    // **CHECK** if entry is NOT NULL ......
    if (entry != null)
    {
       // only when sure that it's not NULL - **THEN** access the entry....
       ConnectionString = entry.ConnectionString;
    }
