    [Association(Storage = "_configurationContentsTable", OtherKey = "ConfigurationContextId")]
    public ConfigurationContentsTable ConfigurationContentsTable
    {
        get { return _configurationContentsTable.Entity; }
        set { _configurationContentsTable.Entity = value; }
    }
