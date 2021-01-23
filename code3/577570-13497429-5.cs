        static string ToXml(object input)
        {
            string output;
            XmlSerializer serializer = CreateSerializer(input.GetType());
            StringBuilder sb = new StringBuilder();
            var settings = new XmlWriterSettings() { OmitXmlDeclaration = true, Encoding =  Encoding.UTF8, Indent = true };
            using (XmlWriter xw = XmlWriter.Create(sb, settings))
            {
                serializer.Serialize(xw, input);
            }
            output = sb.ToString();
            return output;
        }
        static T FromXml<T>(string input)
        {
            T output;
            XmlSerializer serializer = CreateSerializer(typeof(T));
            output = (T)serializer.Deserialize(new StringReader(input));
            return output;
        }
        private static XmlSerializer CreateSerializer(Type incomingType)
        {
            XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
            XmlAttributes newAttributes = new XmlAttributes();
            newAttributes.XmlRoot = new XmlRootAttribute();
            newAttributes.XmlRoot.Namespace = ((XmlTypeAttribute)incomingType.GetCustomAttributes(typeof(XmlTypeAttribute), true)[0]).Namespace;
            attrOverrides.Add(incomingType, newAttributes);
            XmlSerializer serializer = new XmlSerializer(incomingType, attrOverrides);
            return serializer;
        }
