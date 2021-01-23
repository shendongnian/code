    public class LookupMappingsConfigSection: ConfigurationSection
    {
        [ConfigurationProperty("LookupMappings")]
        public LookupMappingsConfigCollection LookupMappings
        {
            get { return ((LookupMappingsConfigCollection)(base["LookupMappings"])); }
        }
    }
    [ConfigurationCollection(typeof(LookupMappingElement))]
    public class LookupMappingsConfigCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new LookupMappingElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LookupMappingElement) element).Name;
        }
        public LookupMappingElement this[int idx]
        {
            get { return (LookupMappingElement)BaseGet(idx); }
        }
      
    }
    public class LookupMappingElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "",IsKey = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
        [ConfigurationProperty("lookupName", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string LookupName
        {
            get { return (string)this["lookupName"]; }
            set { base["lookupName"] = value; }
        }
    }
    //Get the lookup entries
    LookupMappingsConfigSection section = (LookupMappingsConfigSection)ConfigurationManager.GetSection("LookupMappingsSection");
    foreach(LookupMappingElement lookupMapping in section.LookupMappings)
    { 
        //Do something 
    }
