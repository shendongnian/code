    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Xml;
    
    hnamespace Sample 
    {
        public sealed class StringCollectionConfigSection : ConfigurationSection
        {
            public static StringElementCollection Named(string configSection)
            {
                var section = (StringCollectionConfigSection)ConfigurationManager.GetSection(configSection);
                return section.Elements;
            }
        
            [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
            public StringElementCollection Elements
            {
                get { return (StringElementCollection)base[""]; }
                set { base[""] = value; }
            }
        }
        
        [ConfigurationCollection(typeof(StringElement))]
        public sealed class StringElementCollection : ConfigurationElementCollection, IEnumerable<string>
        {
            public StringElement this[int index]
            {
                get { return (StringElement)BaseGet(index); }
                set
                {
                    if (BaseGet(index) != null) { BaseRemoveAt(index); }
                    BaseAdd(index, value);
                }
            }
        
            public new StringElement this[string key]
            {
                get { return (StringElement)BaseGet(key); }
            }
        
            protected override ConfigurationElement CreateNewElement()
            {
                return new StringElement();
            }
        
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((StringElement)element).Value;
            }
        
            public new IEnumerator<string> GetEnumerator()
            {
                var enumerator = base.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    yield return ((StringElement)enumerator.Current).Value;
                }
            }
        }
        
        public class StringElement : ConfigurationElement
        {
            protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
            {
                Value = (string)reader.ReadElementContentAs(typeof(string), null);
            }
            
            public string Value {get; private set; }
        }
    }
