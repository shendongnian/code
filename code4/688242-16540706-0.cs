    string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(registry_key))
    {
        foreach (string subkey_name in key.GetSubKeyNames())
        {
            using (Microsoft.Win32.RegistryKey subkey = key.OpenSubKey(subkey_name))
            {
                if (!object.ReferenceEquals(subkey.GetValue("DisplayName"), null))
                {
                    string[] str = subkey.GetValueNames();
                    string SoftNames = Convert.ToString(subkey.GetValue("DisplayName"));
                    if (SoftNames == "MyAppName")
                    {
                        string Vendor_Publisher = Convert.ToString(subkey.GetValue("Publisher"));
                        string Version = Convert.ToString(subkey.GetValue("DisplayVersion"));
                        string InstallDate = FormatDateTime(subkey.GetValue("InstallDate"));
                    }
    
                }
            }
        }
    }
    private static string FormatDateTime(object ObjInstallDate)
    {
        object FinalDate = DBNull.Value;
        string strDate = Convert.ToString(ObjInstallDate);
        DateTime dtm;
        DateTime.TryParseExact(strDate, new string[] { "yyyyMMdd", "yyyy-MM-dd", "dd-MM-yyyy" }, 
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out dtm);
        if (!String.IsNullOrEmpty(strDate))
        {                
            FinalDate = dtm;
        }
        return FinalDate.ToString();
    }
