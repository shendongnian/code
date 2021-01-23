    public class CommonConfSection : ConfigurationSection
    {
        private const String UserNameProperty = "Username";
        [ConfigurationProperty(UserNameProperty, DefaultValue = "__UNKNOWN_NAME__", IsRequired = false)]
        public String UserName
        {
            get { return (String)this[UserNameProperty]; }
            set { this[UserNameProperty] = value; }
        }
    }
