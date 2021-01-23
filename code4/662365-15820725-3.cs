    [Association(Storage = "_configurationContentsTable", OtherKey = "ConfigurationSectionId")]
    public ConfigurationContentsTable ConfigurationContentsTable
    {
        get { return _configurationContentsTable.Entity; }
        set { _configurationContentsTable.Entity = value; }
    }
