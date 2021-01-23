    class MyMainSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired=true, IsDefaultCollection=true)]
        public AddElementCollection Instances 
        {
            get { return (AddElementCollection) this[""]; }
            set { this[""] = value; }
        }
    }
