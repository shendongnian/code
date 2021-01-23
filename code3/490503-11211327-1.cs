    public class Repository
    {
      public static ConfigurationValues LoadConfigValues()
      {
         var cv = new ConfigurationValues();
    
         string[] lines = File.ReadAllLines("values.cfg");
         foreach (string cfg in lines)
         {
            string[] nameValue = cfg.Split(new char[] { ' ' } ); // To get label/value
            
            if (nameValue[0] == "HOT_STANDBY_FEATURE_ENABLE")
              cv.HotStandbyFeatureEnable = nameValue[1];
            else if (nameValue[0] == "SOME_OTHER_PROPERTY")
              cv.SomeOtherProperty = nameValue[2];
            // Continue for all properties
         }
         return cv;
      }
    
      public static void SaveConfigValues(ConfigurationValues cv)
      {
         var builder = new StringBuilder();
         builder.AppendFormat("HOST_STANDBY_FEATURE_ENABLE {0}\r\n", cv.HostStandbyFeatureEnable);
         // Add the rest of your properties
         File.WriteAllText("values.cfg", builder.ToString());
      }
    }
