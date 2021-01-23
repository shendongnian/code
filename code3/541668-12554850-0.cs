     using (XmlWriter writer = XmlWriter.Create("abc.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Employees");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }   
