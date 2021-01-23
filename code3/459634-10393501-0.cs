    public class MyAppConfig {
      private static _config = null;
      // Configuration is a simple class with a list of properties
      public static Configuration Configuration {
         if (_config == null ) {
             _config = new Configuration();
             // parse XMl file and set properties
         }
         return _config;
      }
    }
