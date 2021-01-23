    public static DateTime GetWindowsInstallationDateTime(string computerName)
    {
    	Microsoft.Win32.RegistryKey key = Microsoft.Win32.RegistryKey.OpenRemoteBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, computerName);
    	key = key.OpenSubKey(@"SOFTWAREMicrosoftWindows NTCurrentVersion", false);
    	if (key != null)
    	{
    		DateTime startDate = new DateTime(1970, 1, 1, 0, 0, 0);
    		Int64 regVal = Convert.ToInt64(key.GetValue("InstallDate").ToString());
     
    		DateTime installDate = startDate.AddSeconds(regVal);
     
    		return installDate;
    	}
     
    	return DateTime.MinValue;
    }
