    public string BuildXml<T>(ICollection<T> anyObject, string keyFather, string keySon)
        {
            var settings = new XmlWriterSettings
            {
                Indent = true
            };
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            StringBuilder builder = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(builder, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(keyFather);
                foreach (var objeto in anyObject)
                {
                    writer.WriteStartElement(keySon);
                    foreach (PropertyDescriptor item in props)
                    {
                        writer.WriteStartElement(item.DisplayName);
                        writer.WriteString(props[item.DisplayName].GetValue(objeto).ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteFullEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                return builder.ToString();
            }
        }
