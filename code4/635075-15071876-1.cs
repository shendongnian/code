    public SomeConstructor() 
      : base(Configuration.ConnectionString) {
    }
    public static Configuration {
      public static string ConnectionString {
        get { 
          /* some logic to determine the appropriate value */
    #if DEBUG
          return ConfigurationManager.ConnectionStrings["DebugConnectionString"]; 
    #else
          return ConfigurationManager.ConnectionStrings["ReleaseConnectionString"]; 
    #endif
        } 
      }
    }
