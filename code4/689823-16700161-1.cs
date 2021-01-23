    [ComRegisterFunction]
    public static void RegisterBHO(Type type)
    {
        RegistryKey key;
        using (key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Browser Helper Objects"))
        {
          RegistryKey bhoKey;
          using (bhoKey = key.CreateSubKey(typeName))
          {
            bhoKey.SetValue(string.Empty, "My Awesone IE Plugin");
            bhoKey.SetValue("NoExplorer", 1, RegistryValueKind.DWord);
          }
        }      
    }
