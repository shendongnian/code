        // Setting Proxy information for IE Settings.
        RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Connections", true);
        byte[] defConnection = (byte[])RegKey.GetValue("DefaultConnectionSettings");
        byte[] savedLegacySetting = (byte[])RegKey.GetValue("SavedLegacySettings");
        if (set)
        {
            defConnection[8] = Convert.ToByte(9);
            savedLegacySetting[8] = Convert.ToByte(9);
        }
        else
        {
            defConnection[8] = Convert.ToByte(1);
            savedLegacySetting[8] = Convert.ToByte(1);
        }
        RegKey.SetValue("DefaultConnectionSettings", defConnection);
        RegKey.SetValue("SavedLegacySettings", savedLegacySetting);
    }
