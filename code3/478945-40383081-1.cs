    // currPath - full file name/path of the exe that you trying to find if it is registered as service
    // displayName - service name that you return if you find it
    private bool TryWinRegistry(string currPath, out string displayName)
    {
        displayName = string.Empty;
          
        try
        {
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\services", false))
            {
                if (regKey == null)
                    return false;
             // we don't know which key because key name is configured by config file and equals to service name
                foreach (string keyName in regKey.GetSubKeyNames())
                {
                    try
                    {
                        using (RegistryKey serviceRegKey = regKey.OpenSubKey(keyName))
                        {
                            if (serviceRegKey == null)
                                continue;
                            string val = serviceRegKey.GetValue("imagePath") as string;
                            if (val != null && String.Equals(val, currPath, StringComparison.OrdinalIgnoreCase))
                            {
                                displayName = serviceRegKey.GetValue("displayName") as string;
                                return true;
                            }
                                    
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
        catch
        {
            return false;
        }
        return false;
    }
