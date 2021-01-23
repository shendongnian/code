    class MyConfigurationElement : ConfigurationElement
    {
    
        // Use public, private or internal, as you see fit.
        private const string PortName = "port";
    
        // Add something like this, if you also want to access the string value
        // and don't want to recompile dependend assemblies when changing the
        // string 'port' to something else.
        // public static readonly PortNameProperty = PortName;
    
        [ConfigurationProperty(PortName, DefaultValue = (int)0, IsRequired = false)]
        [IntegerValidator(MinValue = 0, MaxValue = 8080, ExcludeRange = false)] 
        public int Port  
        {
            get
            {
                return (int)this[PortName];
            }
            set
            {
               this[PortName] = value;
            }
        }    
    }
