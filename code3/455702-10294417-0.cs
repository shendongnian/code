    public static string Server {
      get {
    #if DEBUG
        return ConfigurationManager.AppSettings[key0];
    #else
        return ConfigurationManager.AppSettings[key1];
    #endif
      }
    }
