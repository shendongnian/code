    private static bool isActive; // The new property; put it with the rest of the statics
    public static string get_changedWebSite()
    {
        return changeWebsite;
    }
    
    public static void set_changeWebSite(string website)
    {
        if (isActive) // Check if it is active or not
        {
            changeWebsite = website;
            setting_file.SetKey("changeWebSite", changeWebsite);
        }
    }
    public bool IsActive // Get and set
    { 
      get
      {
         return isActive;
      } 
      set
      {
          isActive = value;
      } 
    }
