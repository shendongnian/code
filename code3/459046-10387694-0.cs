        public static XmlAttributeOverrides GetXmlAttributeOverrides(Type type)
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes attr = new XmlAttributes();
            // Get all interfaces that the "type" implements (is it same as "derivedType" from previously)?
            foreach (Type derived in ClassHandler.GetImplementedInterfaces(type))
            {
                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    XmlAttributeAttribute xmlAttributeAttribute = ClassHandler.GetCustomAttribute<XmlAttributeAttribute>(propertyInfo, true) as XmlAttributeAttribute;
                    if (xmlAttributeAttribute == null) continue;
                    XmlAttributes attr1 = new XmlAttributes();
                    attr1.XmlAttribute = new XmlAttributeAttribute();
                    attr1.XmlAttribute.AttributeName = xmlAttributeAttribute.AttributeName;
                    overrides.Add(derived, propertyInfo.Name, attr1);
                }
            }
            return overrides;
        }
