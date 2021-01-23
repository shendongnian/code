    public static class CustomEnterpriseResource
    {
        public static string GetString(string key)
        {
            return GetString(key, Thread.CurrentThread.CurrentUICulture);
        }
        public static string GetString(string key, string languageCode)
        {
            return GetString(key, new CultureInfo(languageCode));
        }
        public static string GetString(string key, CultureInfo cultureInfo)
        {
            var customKey = ((EnterpriseContext)HttpContext.Current.Items[EnterpriseContext.EnterpriseContextKey]).ResourcePrefix + key;
            
            return Resources.Enterprise.ResourceManager.GetString(customKey, cultureInfo) 
                ?? Resources.Enterprise.ResourceManager.GetString(key, cultureInfo);
        }
    }
