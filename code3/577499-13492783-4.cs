    public static MySettingsExtensions 
    {
      public static string GetMySetting(this IConsProvider provider) 
      {
        //TODO: argument null checks
        return provider["MySetting"];
      }
      public static void SetMySetting(this IConsProvider provider, string val) 
      {
        provider["MySetting"]=val;
      }
    }
