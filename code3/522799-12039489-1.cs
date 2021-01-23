    public static string GetLastOpenSaveFile(string extention)
    {
        RegistryKey regKey = Registry.CurrentUser;
        string lastUsedFolder = string.Empty;
        regKey = regKey.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\OpenSaveMRU");
        if (string.IsNullOrEmpty(extention))
            extention = "html";
        RegistryKey myKey = regKey.OpenSubKey(extention);
        if (myKey == null && regKey.GetSubKeyNames().Length > 0)
            myKey = regKey.OpenSubKey(regKey.GetSubKeyNames()[regKey.GetSubKeyNames().Length - 2]);
        if (myKey != null)
        {
            string[] names = myKey.GetValueNames();
            if (names != null && names.Length > 0)
            {
                lastUsedFolder = (string)myKey.GetValue(names[names.Length - 2]);
            }
        }
        return lastUsedFolder;
    }
