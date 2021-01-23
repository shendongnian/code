    public static class Settings
    {
       public static name = "";
    
       static Settings()
       {
        ReInitialize();
       }
    
       public static void ReInitialize()
       {
          name = "My name is re-initialized";
       }
    }
    
    
    Settings.name = "My name has changed";
    // Console.WriteLine(Settings.name);
    Settings.ReInitialize(); //name is "My name is re-initialized"
    // Console.WriteLine(Settings.name);
