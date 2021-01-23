     /// <summary>
        /// Checks or unchecks the IE Options Connection setting of "Automatically detect Proxy"
        /// </summary>
        /// <param name="set">Provide 'true' if you want to check the 'Automatically detect Proxy' check box. To uncheck, pass 'false'</param>
        public void IEAutoDetectProxy(bool set)
        {
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
