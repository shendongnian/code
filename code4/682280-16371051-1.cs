    var stream = new MemoryStream();	
    using (XmlWriter writer = XmlWriter.Create(stream))
    {
        writer.WriteStartDocument();
        writer.WriteStartElement("Employees");
        
        foreach (Employee employee in employees)
        {
           writer.WriteStartElement("Employee");
           writer.WriteElementString("Id", employee.Id.ToString());
           writer.WriteElementString("FirstName", employee.FirstName);
           writer.WriteElementString("LastName", employee.LastName);
           writer.WriteElementString("Salary", employee.Salary);
           writer.WriteEndElement();
        }
        writer.WriteEndElement();
        writer.WriteEndDocument();
    }
    string strXml = System.Text.ASCIIEncoding.UTF8.GetString(stream.ToArray())
                
