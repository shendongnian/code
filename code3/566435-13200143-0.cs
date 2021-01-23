    string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    var dict = new Dictionary<string, RegistryKey>();
    using(var key = Registry.LocalMachine.OpenSubKey(registry_key))
    {
        foreach(string subkey_name in key.GetSubKeyNames())
        {
        	using(var subkey = key.OpenSubKey(subkey_name))
        	{
                     dict.Add(subkey.GetValue("DisplayName"), subkey);
        	}
        }
    }
