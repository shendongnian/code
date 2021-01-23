    public class RuntimeXmlSerializerAttribute : XmlIgnoreAttribute { }
    public class RuntimeXmlSerializer
    {
        private Type m_type;
        private XmlSerializer m_regularXmlSerializer;
        private const string k_FullClassNameAttributeName = "FullAssemblyQualifiedTypeName";
        public RuntimeXmlSerializer(Type i_subjectType)
        {
            this.m_type = i_subjectType;
            this.m_regularXmlSerializer = new XmlSerializer(this.m_type);
        }
        public void Serialize(object i_objectToSerialize, Stream i_streamToSerializeTo)
        {
            StringWriter sw = new StringWriter();
            this.m_regularXmlSerializer.Serialize(sw, i_objectToSerialize);
            XDocument objectXml = XDocument.Parse(sw.ToString());
            sw.Dispose();
            SerializeExtra(i_objectToSerialize,objectXml);
            string res = objectXml.ToString();
            byte[] bytesToWrite = Encoding.UTF8.GetBytes(res);
            i_streamToSerializeTo.Write(bytesToWrite, 0, bytesToWrite.Length);
        }
        public object Deserialize(Stream i_streamToSerializeFrom)
        {
            string xmlContents = new StreamReader(i_streamToSerializeFrom).ReadToEnd();
            StringReader sr;
            sr = new StringReader(xmlContents);
            object res = this.m_regularXmlSerializer.Deserialize(sr);
            sr.Dispose();
            sr = new StringReader(xmlContents);
            XDocument doc = XDocument.Load(sr);
            sr.Dispose();
            deserializeExtra(res, doc);
            return res;
        }
        private void deserializeExtra(object i_desirializedObject, XDocument i_xmlToDeserializeFrom)
        {
            IEnumerable propertiesToDeserialize = i_desirializedObject.GetType()
                .GetProperties().Where(p => p.GetCustomAttributes(true)
                    .FirstOrDefault(a => a.GetType() ==
                        typeof(RuntimeXmlSerializerAttribute)) != null);
            foreach (PropertyInfo prop in propertiesToDeserialize)
            {
                XElement propertyXml = i_xmlToDeserializeFrom.Descendants().FirstOrDefault(e =>
                    e.Name == prop.Name);
                if (propertyXml == null) continue;
                XElement propertyValueXml = propertyXml.Descendants().FirstOrDefault();
                Type type = Type.GetType(propertyValueXml.Attribute(k_FullClassNameAttributeName).Value.ToString());
                XmlSerializer srl = new XmlSerializer(type);
                object deserializedObject = srl.Deserialize(propertyValueXml.CreateReader());
                prop.SetValue(i_desirializedObject, deserializedObject, null);
            }
        }
        private void SerializeExtra(object objectToSerialize, XDocument xmlToSerializeTo)
        {
            IEnumerable propertiesToSerialize =
                objectToSerialize.GetType().GetProperties().Where(p =>
                    p.GetCustomAttributes(true).FirstOrDefault(a =>
                        a.GetType() == typeof(RuntimeXmlSerializerAttribute)) != null);
            foreach (PropertyInfo prop in propertiesToSerialize)
            {
                XElement serializedProperty = new XElement(prop.Name);
                serializedProperty.AddFirst(serializeObjectAtRuntime(prop.GetValue(objectToSerialize, null)));
                xmlToSerializeTo.Descendants().First().Add(serializedProperty); //TODO
            }
        }
        private XElement serializeObjectAtRuntime(object i_objectToSerialize)
        {
            Type t = i_objectToSerialize.GetType();
            XmlSerializer srl = new XmlSerializer(t);
            StringWriter sw = new StringWriter();
            srl.Serialize(sw, i_objectToSerialize);
            XElement res = XElement.Parse(sw.ToString());
            sw.Dispose();
            XAttribute fullClassNameAttribute = new XAttribute(k_FullClassNameAttributeName, t.AssemblyQualifiedName);
            res.Add(fullClassNameAttribute);
            return res;
        }
    }
