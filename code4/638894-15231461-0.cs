    using System.Configuration;
    using System.ComponentModel;
    class DomainConfig : ConfigurationSection
    {     
        [ConfigurationProperty("DoubleArray")]
        [TypeConverter(typeof(CommaDelimitedStringCollectionConverter))]
        public CommaDelimitedStringCollection DoubleArray
        {
            get { return (CommaDelimitedStringCollection)base["DoubleArray"]; }
        }
    }
