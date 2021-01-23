        public static XmlAttributeOverrides GetXmlAttributeOverrides(Type type)
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            foreach (Type derived in ClassHandler.GetImplementedInterfaces(type))
            {
                foreach (PropertyInfo propertyInfo in derived.GetProperties())
                {
                    XmlAttributeAttribute xmlAttributeAttribute = ClassHandler.GetCustomAttribute<XmlAttributeAttribute>(propertyInfo, true) as XmlAttributeAttribute;
                    if (xmlAttributeAttribute == null) continue;
                    XmlAttributes attr1 = new XmlAttributes();
                    attr1.XmlAttribute = new XmlAttributeAttribute();
                    attr1.XmlAttribute.AttributeName = xmlAttributeAttribute.AttributeName;
                    overrides.Add(type, propertyInfo.Name, attr1);
                }
            }
            return overrides;
        }
