    string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    var dict = new Dictionary<string, RegistryKey>();
    using(var key = Registry.LocalMachine.OpenSubKey(registryKey))
    {
        foreach(string subkeyName in key.GetSubKeyNames())
        {
            using(var subkey = key.OpenSubKey(subkeyName))
            {
                dict.Add(subkey.GetValue("DisplayName"), subkey);
            }
        }
    }
