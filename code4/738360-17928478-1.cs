    public static string GetConnString()
    {
       string connString = ConfigurationSettings.AppSettings[GetConfigKey("database")];
       return connString;
    }
    public static string GetConfigKey(string baseKey)
    {
       string str = baseKey;
       if (GetHostName().StartsWith("BobsPC"))
       {
           // set str = the appropriate string = DB.[hostname].config
       }
       else if (GetHostName().StartsWith("JacksPC"))
       {
           // set str = the appropriate string = DB.[hostname].config
       }
       return str;
