    public static class SettingManager
    
    {
    private ConcurrentDictionary<GUID,Setting> settings= new ConcurrentDictionary<GUID,Setting>;
    GetSetting(Guid siteGUID)
    {
    settings.TryGet(siteGuid);
    Lastrefreshed = DateTime.Now;
    //other code
    }
    Private DateTime LastRefreshedOn = DateTime.Now;
    public void PopulateSetingsDic()
    {
    //populate the settings dictionary by getting the values from the database
    }
    }
