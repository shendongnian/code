    string xmlString = null;
    using (StringWriter sw = new StringWriter())
    {
        XmlTextWriter writer = new XmlTextWriter(sw);
        writer.Formatting = Formatting.Indented; // if you want it indented
    
        writer.WriteStartDocument();
        writer.WriteStartElement("Employees");
    
        foreach (Employee employee in employees)
        {
            writer.WriteStartElement("Employee");
    
            writer.WriteElementString("ID", employee.Id.ToString());
            writer.WriteElementString("FirstName", employee.FirstName);
            writer.WriteElementString("LastName", employee.LastName);
            writer.WriteElementString("Salary", employee.Salary.ToString());
    
            writer.WriteEndElement();
        }
    
        writer.WriteEndElement();
        writer.WriteEndDocument();
    
        xmlString = sw.ToString();
    }
