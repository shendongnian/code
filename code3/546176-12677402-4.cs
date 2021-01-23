    // Define the "font" element 
    // with "name" and "size" attributes. 
    public class FontElement : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public String Name
        {
            get
            {
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
        [ConfigurationProperty("size", DefaultValue = "12", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MaxValue = 24, MinValue = 6)]
        public int Size
        {
            get
            { return (int)this["size"]; }
            set
            { this["size"] = value; }
        }
    }
