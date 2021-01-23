    namespace Foo.Web.Applications.CustomConfigurationSections
    {
        public class XslTemplateConfiguration : ConfigurationSection
        {
            [ConfigurationProperty("xslTemplates")]
            public XslTemplateElementCollection XslTemplates
            {
                get { return this["xslTemplates"] as XslTemplateElementCollection; }
            }
        }
    
        public class XslTemplateElement : ConfigurationElement
        {
            [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
            public string Name
            {
                get { return this["name"] as string; }
                set { this["name"] = value; }
            }
    
            [ConfigurationProperty("path", IsRequired = true)]
            public string Path
            {
                get { return this["path"] as string; }
                set { this["path"] = value; }
            }
        }
    
        public class XslTemplateElementCollection : ConfigurationElementCollection
        {
            public XslTemplateElement this[object key]
            {
                get { return base.BaseGet(key) as XslTemplateElement; }
            }
    
            public override ConfigurationElementCollectionType CollectionType
            {
                get { return ConfigurationElementCollectionType.BasicMap; }
            }
    
            protected override string ElementName
            {
                get { return "xslTemplate"; }
            }
    
            protected override bool IsElementName(string elementName)
            {
                bool isName = false;
                if (!String.IsNullOrEmpty(elementName))
                    isName = elementName.Equals("xslTemplate");
                return isName;
            }
    
            protected override ConfigurationElement CreateNewElement()
            {
                return new XslTemplateElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((XslTemplateElement)element).Name;
            }
        }
    }
