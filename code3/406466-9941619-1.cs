    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    
    namespace RecursiveCustomConfiguration
    {
    
        public class MonitorConfig : ConfigurationSection
        {
            public static MonitorConfig GetConfig()
            {
                return ConfigurationManager.GetSection("monitorSettings") as MonitorConfig;
            }
    
            [ConfigurationProperty("monitors", IsDefaultCollection = true, IsRequired = true)]
            [ConfigurationCollection(typeof(MonitorCollection), AddItemName = "monitor")]
            public MonitorCollection Monitors
            {
                get
                {
                    return this["monitors"] as MonitorCollection;
                }
            }
    
        }
    
        public class MonitorCollection : ConfigurationElementCollection
        {
    
            public Monitor this[int index]
            {
                get
                {
                    return base.BaseGet(index) as Monitor;
                }
                set
                {
                    if (base.BaseGet(index) != null)
                    {
                        base.BaseRemoveAt(index);
                    }
                    this.BaseAdd(index, value);
                }
            }
    
            public Monitor this[object description]
            {
                get
                {
                    return base.BaseGet(description) as Monitor;
                }
            }
    
            protected override ConfigurationElement CreateNewElement()
            {
                return new Monitor();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((Monitor)element).Description;
            }
    
            public override ConfigurationElementCollectionType CollectionType
            {
                get { return ConfigurationElementCollectionType.BasicMap; }
            }
    
            protected override string ElementName
            {
                get { return "monitor"; }
            }
    
        }
    
        public class Monitor : ConfigurationElement
        {
    
            [ConfigurationProperty("description", IsRequired = true)]
            public string Description
            {
                get
                {
                    return this["description"] as string;
                }
            }
    
            [ConfigurationProperty("monitors", IsRequired = false)]
            public MonitorCollection Monitors
            {
                get
                {
                    return this["monitors"] as MonitorCollection;
                }
            }
    
        }
    
    }
