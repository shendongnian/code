    public class BounceProvidersSection : ConfigurationSection
    {
        [ConfigurationCollection(typeof(ConfigCollection<BounceProviderConfig>), AddItemName = "Provider")]
        [ConfigurationProperty("Providers", IsRequired = true)]
        public ConfigCollection<BounceProviderConfig> Providers
        {
            get { return (ConfigCollection<BounceProviderConfig>)this["Providers"]; }
            set { this["Providers"] = value; }
        }                
    }
    
    public class BounceProviderConfig : ConfigurationElement
    {
        [ConfigurationProperty("Id", IsRequired = true)]
        public int Id
        {
            get { return (int)this["Id"]; }
            set { this["Id"] = value; }
        }
           
        [ConfigurationProperty("Columns", IsRequired = false)]
        public BounceProviderColumns Columns
        {
            get { return (BounceProviderColumns)this["Columns"]; }
            set { this["Columns"] = value; }
        }
    
        public static BounceProviderConfig GetByProviderId(int providerId)
        {
            var section = ConfigUtils.GetConfigurationSection<BounceProvidersSection>("BounceProviders");
            foreach (BounceProviderConfig provider in section.Providers)
            {
                if (provider.Id == providerId)
                    return provider;
            }
    
            return null;
        }
    }
    
    public class BounceProviderColumns : ConfigurationElement
    {
        [ConfigurationProperty("Email", IsRequired = true)]
        public ColumnConfig Email
        {
            get { return (ColumnConfig)this["Email"]; }
            set { this["Email"] = value; }
        }
    
        [ConfigurationProperty("Date", IsRequired = true)]
        public DateColumnConfig Date
        {
            get { return (DateColumnConfig)this["Date"]; }
            set { this["Date"] = value; }
        }
    
        [ConfigurationProperty("Message", IsRequired = true)]
        public ColumnConfig Message
        {
            get { return (ColumnConfig)this["Message"]; }
            set { this["Message"] = value; }
        }        
    }
    
    public class ColumnConfig : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
            set { this["Name"] = value; }
        }
    }
