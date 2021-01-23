    [Association(Storage = "_configurationContextsTable", ThisKey = "ConfigurationContextId")]
    public ConfigurationContextsTable ConfigurationContextsTable
    {
        get { return _configurationContextsTable.Entity; }
        set { _configurationContextsTable.Entity = value; }
    }
    [Association(Storage = "_configurationSectionsTable", ThisKey = "ConfigurationSectionId")]
    public ConfigurationSectionsTable ConfigurationSectionsTable
    {
        get { return _configurationSectionsTable.Entity; }
        set { _configurationSectionsTable.Entity = value; }
    }
