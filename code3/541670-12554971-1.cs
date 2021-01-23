     using (XmlWriter writer = XmlWriter.Create(@"C:\folder\abc.xml"))
     {
               writer.WriteStartDocument();
               writer.WriteStartElement("Employees");
               writer.WriteEndElement();
               writer.WriteEndDocument();
      }
