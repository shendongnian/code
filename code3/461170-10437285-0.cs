    class MyConfigurationElement : ConfigurationElement
    {
        private static ConfigurationPropertyCollection _properties = new ConfigurationPropertyCollection();
        private static ConfigurationProperty _portProperty = new COnfigurationProperty("port", ..... ); // Will leave as example for you to add validator etc.
        static MyConfigurationElement()
        {
             _properties.Add(_portProperty);
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
        public int Port  
        {
            get
            {
                return (int)this[_portProperty];
            }
            set
            {
               this[_portProperty] = value;
            }
        }    
    }
