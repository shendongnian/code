    public class Method: ConfigurationElement
    {
        [ConfigurationProperty("SearchMethod", IsKey = true, IsRequired = true)]
        public string SearchMethod
        {
            get { return base["SearchMethod"] as string; }
            set { base["SearchMethod"] = value; }
        }
        [ConfigurationProperty("Weight", IsRequired = true)]
        public string Weight
        {
            get { return base["Weight"] as string; }
            set { base["Weight"] = value; }
        }
        //REST OF YOUR CLASS
    }
