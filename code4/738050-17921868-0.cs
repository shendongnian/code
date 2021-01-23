    public override SettingsPropertyCollection Properties
    {
        get
        {
            var properties = base.Properties;
            properties["SQLServer"].DefaultValue = 
                String.Format("John Doe {0}", DateTime.Now);
            return properties;
        }
    }
