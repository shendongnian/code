    private RegistryKey keyR = Registry.CurrentUser.OpenSubKey("Software\\YourKey");
    private RegistryKey keyW = Registry.CurrentUser.CreateSubKey("Software\\YourKey");
    public static string version
    {
        get { return keyR.GetValue("VERSION", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString(); }
        set { keyW.SetValue("VERSION", value, RegistryValueKind.String); }
    }
