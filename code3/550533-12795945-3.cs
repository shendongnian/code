    // productName is name you assigned to your app in the 
    // Project properties -> Publish -> Publish Settings
	public static string GetInstalledFromDir(string productName)
	{
	    using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall"))
	    {
	        if (key != null)
	        {
	            var appKey = key.GetSubKeyNames().FirstOrDefault(x => GetValue(key, x, "DisplayName") == productName);
	            return appKey == null ? null : GetValue(key, appKey, "UrlUpdateInfo");
	        }
	    }
	    return null;
	}
	private static string GetValue(RegistryKey key, string app, string value)
	{
	    using (var subKey = key.OpenSubKey(app))
	    {
	        if (subKey == null || !subKey.GetValueNames().Contains(value)) 
	        { 
	        	return null; 
	        }
	        
	        return subKey.GetValue(value).ToString();
	    }
	}
