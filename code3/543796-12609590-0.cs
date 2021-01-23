    public class SettingsData
    {
      public string Setting1;
      public string Setting2;
    }
    
    public static class DataHolder
    {
      public static SettingsData Settings = new SettingsData();
      static DataHolder() 
      {
        // open connection to db and query for values
        Settings.Setting1 = <value from db>;
        Settings.Setting2 = <value from db>;
      }
    }
