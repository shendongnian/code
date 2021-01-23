    // <summary>
    // This class is used to manage the Cached AppSettings
    // from the Database
    // </summary>
    public class AppSettings
    {
    // <summary>
    // This indexer is used to retrieve AppSettings from Memory
    // </summary>
    public string this[string Name]
    {
      get
      {
         //See if we have an AppSettings Cache Item
         if (HttpContext.Current.Cache["AppSettings"] == null)
         {
            int? TenantID = 0;
            //Look up the URL and get the Tenant Info
            using (ApplContext dc =
               new ApplContext())
            {
               Site result =
                      dc.Sites
                      .Where(a => a.Host ==
                         HttpContext.Current.Request.Url.
                            Host.ToLower())
                      .FirstOrDefault();
               if (result != null)
               {
                  TenantID = result.SiteID;
               }
            }
            AppSettings.LoadAppSettings(TenantID);
         }
         Hashtable ht =
           (Hashtable)HttpContext.Current.Cache["AppSettings"];
         if (ht.ContainsKey(Name))
         {
            return ht[Name].ToString();
         }
         else
         {
            return string.Empty;
         }
      }
    }
    // <summary>
    // This Method is used to load the app settings from the
    // database into memory
    // </summary>
    public static void LoadAppSettings(int? TenantID)
    {
      Hashtable ht = new Hashtable();
      //Now Load the AppSettings
      using (ShoelaceContext dc =
         new ShoelaceContext())
      {
          //settings are turned off
          // no specific settings per user needed currently
         //var results = dc.AppSettings.Where(a =>
         //   a.in_Tenant_Id == TenantID);
         //foreach (var appSetting in results)
         //{
         //   ht.Add(appSetting.vc_Name, appSetting.vc_Value);
         //}
                    ht.Add("TenantID", TenantID);
      }
      //Add it into Cache (Have the Cache Expire after 1 Hour)
      HttpContext.Current.Cache.Add("AppSettings",
         ht, null,
         System.Web.Caching.Cache.NoAbsoluteExpiration,
         new TimeSpan(1, 0, 0),
         System.Web.Caching.CacheItemPriority.NotRemovable, null);
         }
      }
