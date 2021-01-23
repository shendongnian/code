    private RegistryKey keyR = Registry.CurrentUser.OpenSubKey("Software\\YourKey",true);
    private RegistryKey keyW = Registry.CurrentUser.CreateSubKey("Software\\YourKey");
    public string version
    {
        get { return keyR.GetValue("VERSION", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString(); }
        set { keyW.SetValue("VERSION", value, RegistryValueKind.String); }
    }
