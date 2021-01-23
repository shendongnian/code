    public class ViewFilterElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 20)]
        public String Name
        {
            get { return (String)this["name"]; } set { this["name"] = value; }
        }
        [ConfigurationProperty("regex", DefaultValue = "", IsRequired = false)]
        public String Regex
        {
            get { return (String)this["regex"]; } set { this["regex"] = value; }
        }
        [ConfigurationProperty("redirect", DefaultValue = "", IsRequired = false)]
        public String Redirect
        {
            get { return (String)this["redirect"]; } set { this["redirect"] = value; }
        }
    }
