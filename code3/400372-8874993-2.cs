    public class Repository : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)this["key"]; }
        }
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["value"]; }
        }
    }
    public class RepositoryCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Repository();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as Repository).Key;
        }
        public Repository this[int index]
        {
            get { return base.BaseGet(index) as Repository; }
        }
        public new Repository this[string key]
        {
            get { return base.BaseGet(key) as Repository; }
        }
    }
    public class MyConfig : ConfigurationSection
    {
        [ConfigurationProperty("currentRepository", IsRequired = true)]
        private string InternalCurrentRepository
        {
            get { return (string)this["currentRepository"]; }
        }
        [ConfigurationProperty("repositories", IsRequired = true)]
        private RepositoryCollection InternalRepositories
        {
            get { return this["repositories"] as RepositoryCollection; }
        }
    }
