    public static class MyConfig
    {
      static MyConfig() { LoadConfigData(); }
      
      public static string ConnectionString
      {
        get
        {
          if (_connectionString == null) { LoadConfigData(); } //assignment of static data done here
            return _connectionString;
        }
      }
      private static string _connectionString = null;
    
      // repeat for other config-settings...
    }
