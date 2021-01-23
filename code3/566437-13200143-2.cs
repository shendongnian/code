    string registryKey = 
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    var dict = new Dictionary<string, RegistryKey>();
     
      using (var key = Registry.LocalMachine.OpenSubKey(registryKey))
      {
        var query = from a in
        key.GetSubKeyNames()
        let r = key.OpenSubKey(a)
        select new
          {
            displayName = r.GetValue("DisplayName")
            subKey = r
          };
     
        foreach (var item in query)
        {
           dict.Add(item.displayName, item.subKey);
        }
      }
