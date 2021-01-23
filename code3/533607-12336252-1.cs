     public static Type2 ConvertType1ToType2<Type1, Type2>(Type1 type1)
        {
            using (System.IO.MemoryStream objectStream = new System.IO.MemoryStream())
            {
                 XmlRootAttribute root = new XmlRootAttribute("Book");
                //Get All MemberInfo of Type1
                Type objType1 = type1.GetType();
                System.Reflection.MemberInfo[] objType1Member = objType1.GetMembers();
                List<Type> extraTypesForType1 = new List<Type>();
                //Type1 => XmlAttributeOverrides
                XmlAttributeOverrides Type1overrides = new XmlAttributeOverrides();
                foreach (System.Reflection.MemberInfo m in objType1Member)
                {
                    if (m.MemberType.Equals( System.Reflection.MemberTypes.Property))
                    {
                        XmlAttributes attributes = new XmlAttributes();
                        attributes.XmlElements.Add(new XmlElementAttribute(m.Name));
                        Type1overrides.Add(typeof(Type1), m.Name, attributes);
                        extraTypesForType1.Add(m.MemberType.GetType());
                    }
                                      
                }
                XmlSerializer type1Serializer = new XmlSerializer(typeof(Type1), Type1overrides, extraTypesForType1.ToArray(),root,"");
                //Type2 => XmlAttributeOverrides
                Type objType2 = type1.GetType();
                System.Reflection.MemberInfo[] objType2Member = objType1.GetMembers();
                List<Type> extraTypesForType2 = new List<Type>();
                XmlAttributeOverrides Type2overrides = new XmlAttributeOverrides();
                foreach (System.Reflection.MemberInfo m in objType2Member)
                {
                    if (m.MemberType.Equals(System.Reflection.MemberTypes.Property))
                    {
                        XmlAttributes attributes = new XmlAttributes();
                        attributes.XmlElements.Add(new XmlElementAttribute(m.Name));
                        Type2overrides.Add(typeof(Type2), m.Name, attributes);
                        extraTypesForType2.Add(m.MemberType.GetType());
                    }
                }
                XmlSerializer type2Deserializer = new XmlSerializer(typeof(Type2), Type2overrides, extraTypesForType2.ToArray(),root,"");
                type1Serializer.Serialize(objectStream, type1);
                objectStream.Position = 0;
                Type2 t = (Type2)type2Deserializer.Deserialize(objectStream);
                return t;
            }
