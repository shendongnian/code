    public FormMain()
    {
        InitializeComponent();
        var registrySettingsProvider = new RegistrySettingsProvider();
        Settings.Default.Providers.Add(registrySettingsProvider);
        foreach (SettingsProperty property in Settings.Default.Properties)
        {
            property.Provider = registrySettingsProvider;
        }
    }
