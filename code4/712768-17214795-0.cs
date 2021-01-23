    [ConfigurationProperty("Service", IsRequired = true)]
    public string Service
     {
     ...
     }
    public class ServiceConfigCollection : ConfigurationElementCollection
    {
        public ServiceConfig this[int index]
        {
            get
            {
                return base.BaseGet(index) as ServiceConfig;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }
        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new ServiceConfig();
        }
        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((ServiceConfig)element).Service;
        }
    }
    public class ServiceConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Entries", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ServiceConfigCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ServiceConfigCollection Entries
        {
            get
            {
                return (ServiceConfigCollection)base["Entries"];
            }
        }
    }
