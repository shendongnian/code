    string registryKey =
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    using (Microsoft.Win32.RegistryKey key = 
        Registry.LocalMachine.OpenSubKey(registryKey))
    {
        (from a in key.GetSubKeyNames()
        let r = key.OpenSubKey(a)
        select new
        {
            DisplayName = r.GetValue("DisplayName"),
            RegistryKey = r
        })
      .Where(c => c.Application != null)
      .ToDictionary(k=>k.DisplayName, v=>v.RegistryKey);
    }
