    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    namespace PluginConfiguration
    {
        public class PluginConfigSection : ConfigurationSection
        {
            [ConfigurationProperty("Plugins", IsDefaultCollection = true)]
            [ConfigurationCollection(typeof(PluginCollection), AddItemName = "Plugin")]
            public PluginCollection Plugins
            {
                get
                {
                    PluginCollection coll = (PluginCollection)base["Plugins"];
                    return coll;
                }
            }
        }
        public class PluginCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new MessageMappingElementCollection();
            }
            protected override object GetElementKey(ConfigurationElement element)
            {
                MessageMappingElementCollection coll = element as MessageMappingElementCollection;
                return coll.Name;
            }
        }
        public class MessageMappingElementCollection : ConfigurationElementCollection
        {
            [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
            public string Name
            {
                get { return this["name"].ToString(); }
                set { this["name"] = value; }
            }
            protected override ConfigurationElement CreateNewElement()
            {
                return new MessageMappingElement();
            }
            protected override object GetElementKey(ConfigurationElement element)
            {
                MessageMappingElement msgElement = element as MessageMappingElement;
                string ret = String.Format("{0}|{1}", msgElement.MessageType, msgElement.MessageSubType);
                return ret;
            }
        }
        public sealed class MessageMappingElement : ConfigurationElement
        {
            public MessageMappingElement()
            {
                MessageType = 0;
                MessageSubType = 0;
                RingTone = "";
                Description = "";
                Vibrate = "";
            }
            [ConfigurationProperty("MessageType", IsRequired = true)]
            public int MessageType
            {
                get { return int.Parse(this["MessageType"].ToString()); }
                set { this["MessageType"] = value; }
            }
            [ConfigurationProperty("MessageSubType", IsRequired = false)]
            public int MessageSubType
            {
                get { return int.Parse(this["MessageSubType"].ToString()); }
                set { this["MessageSubType"] = value; }
            }
            [ConfigurationProperty("RingTone", IsRequired = false)]
            public string RingTone
            {
                get { return this["RingTone"].ToString(); }
                set { this["RingTone"] = value; }
            }
            [ConfigurationProperty("Description", IsRequired = false)]
            public string Description
            {
                get { return this["Description"].ToString(); }
                set { this["Description"] = value; }
            }
            [ConfigurationProperty("Vibrate", IsRequired = false)]
            public string Vibrate
            {
                get { return this["Vibrate"].ToString(); }
                set { this["Vibrate"] = value; }
            }
        }
    }
