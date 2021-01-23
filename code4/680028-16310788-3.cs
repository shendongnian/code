    public class ClaimHeaderSection : ConfigurationSection
    {
        [ConfigurationProperty("property", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ClaimHeaderCollection), 
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ClaimHeaderCollection ClaimHeaders
        {
            get
            {
                return (ClaimHeaderCollection)this["property"];
            }
            set
            { this["property"] = value; }
        }
        public static ClaimHeaderSection GetConfiguration()
        {
            return GetConfiguration("propertyValuesGroup/propertyValues");
        }
        public static ClaimHeaderSection GetConfiguration(string section) 
        {
            return ConfigurationManager.GetSection(section) as ClaimHeaderSection;
        }
    }
