    public EditConfigurationViewModel(string id = null)
    {
        Guid value;
        if (id == null || !Guid.TryParse(id, out value))
        {
            Configuration = new ConfigurationSet();
        }
        else
        {
            Configuration = ConfigDataStore.GetConfiguration(Guid.Parse(id));
        }
    }
