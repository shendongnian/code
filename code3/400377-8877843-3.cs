    public class MySection : ConfigurationSection
    {
        [ConfigurationProperty("MyCollection", Options = ConfigurationPropertyOptions.IsRequired)]
        public MyCollection MyCollection
        {
            get
            {
                return (MyCollection)this["MyCollection"];
            }
        }
    }
    
    [ConfigurationCollection(typeof(EntryElement), AddItemName = "entry", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class MyCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EntryElement();
        }
    
        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");
    
            return ((EntryElement)element).Name;
        }
    
        [ConfigurationProperty("default", IsRequired = false)]
        public string Default
        {
            get
            {
                return (string)base["default"];
            }
        }
    }
    
    public class EntryElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
        }
    }
