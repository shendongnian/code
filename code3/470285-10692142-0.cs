    class CustomConfig : ConfigurationSection
    {
        private readonly CustomElementCollection entries =
            new CustomElementCollection();
        [ConfigurationProperty("customEntries", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(CustomElementCollection), AddItemName = "add")]
        public CustomElementCollection CustomEntries { get { return entries; } }
    }
    class CustomElementCollection : ConfigurationElementCollection
    {
        public CustomElement this[int index]
        {
            get { return (CustomElement) BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new CustomElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CustomElement)element).Name;
        }
    }
    class CustomElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }
        [ConfigurationProperty("direction", IsRequired = true)]
        public string Direction
        {
            get { return this["direction"] as string; }
            set { this["direction"] = value; }
        }
        [ConfigurationProperty("filePath", IsRequired = true)]
        public string FilePath
        {
            get { return this["filePath"] as string; }
            set { this["filePath"] = value; }
        }
    }
