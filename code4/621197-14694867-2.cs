        void objectToXMLFile(String fn, object o)
        {
            XmlTextWriter textWriter = new XmlTextWriter(fn, null);
            System.Type type = o.GetType();
            PropertyInfo[] piList = type.GetProperties();
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("attributeList");
            foreach (PropertyInfo pi in piList)
            {
                textWriter.WriteStartElement("attribute");
                textWriter.WriteStartElement("name");
                textWriter.WriteString(pi.Name);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("value");
                textWriter.WriteString(pi.GetValue(o).ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("dataType");
                textWriter.WriteString(pi.PropertyType.Name);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
            }
            textWriter.WriteEndElement();
            textWriter.WriteEndDocument();
            textWriter.Close();
        }
