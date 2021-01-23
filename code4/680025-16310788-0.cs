    public class ClaimHeaderCollection : ConfigurationElementCollection 
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ClaimHeaderElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ClaimHeaderElement)element).Name;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }
    }
