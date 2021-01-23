    namespace Demo.ServiceMonitor
    {
        using System;
        using System.Configuration;
    
        public class ServiceMonitorSection : ConfigurationSection
        {
            [ConfigurationCollection(typeof(ServiceTestGroupElementCollection), AddItemName = "serviceTestGroup")]
            [ConfigurationProperty("serviceTestGroups", IsRequired = true)]
            public ServiceTestGroupElementCollection ServiceTestGroups
            {
                get { return this["serviceTestGroups"] as ServiceTestGroupElementCollection; }
                set { this["serviceTestGroups"] = value; }
            }
        }
    
        public class ServiceTestGroupElementCollection : ConfigurationElementCollection
        {
            public ServiceTestGroupElement this[int index]
            {
                get { return (ServiceTestGroupElement)this.BaseGet(index); }
                set
                {
                    if (this.BaseGet(index) != null)
                    {
                        this.BaseRemoveAt(index);
                        this.BaseAdd(index, value);
                    }
                }
            }
    
            public ServiceTestGroupElement this[string Name]
            {
                get { return (ServiceTestGroupElement)this.BaseGet(Name); }
            }
    
            protected override ConfigurationElement CreateNewElement()
            {
                return new ServiceTestGroupElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((ServiceTestGroupElement)element).Name;
            }
        }
    
        public class ServiceTestGroupElement : ConfigurationElement
        {
            [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
            public string Name
            {
                get { return this["name"] as string; }
                set { this["name"] = value; }
            }
    
            [ConfigurationCollection(typeof(ServiceTestElementCollection), AddItemName = "serviceTest")]
            [ConfigurationProperty("serviceTests", IsKey = false, IsRequired = true)]
            public ServiceTestElementCollection ServiceTests
            {
                get { return this["serviceTests"] as ServiceTestElementCollection; }
                set { this["serviceTests"] = value; }
            }
        }
    
        public class ServiceTestElementCollection : ConfigurationElementCollection
        {
            public ServiceTestElement this[int index]
            {
                get { return (ServiceTestElement)this.BaseGet(index); }
                set
                {
                    if (this.BaseGet(index) != null)
                    {
                        this.BaseRemoveAt(index);
                        this.BaseAdd(index, value);
                    }
                }
            }
    
            public ServiceTestElement this[string Name]
            {
                get { return (ServiceTestElement)this.BaseGet(Name); }
            }
    
            protected override ConfigurationElement CreateNewElement()
            {
                return new ServiceTestElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((ServiceTestElement)element).Uri;
            }
        }
    
        public class ServiceTestElement : ConfigurationElement
        {
            [ConfigurationProperty("uri", IsKey = true, IsRequired = true)]
            public Uri Uri
            {
                get { return this["uri"] as Uri; }
                set { this["uri"] = value; }
            }
    
            [ConfigurationProperty("expectedResponseTime", IsKey = false, IsRequired = true)]
            public int ExpectedResponseTime
            {
                get { return (int)this["expectedResponseTime"]; }
                set { this["expectedResponseTime"] = value; }
            }
        }
    }
