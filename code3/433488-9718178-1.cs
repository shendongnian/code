    public void Save()
    {
        Configuration config = 
                ConfigurationManager.OpenExeConfiguration(spath);
        CountryConfig section = (CountryConfig)config.Sections["Country"];
        section.States = this.States; //Copy the changed data
        config.Save(ConfigurationSaveMode.Full);
    }
