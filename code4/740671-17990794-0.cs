    XmlDocument doc=new XmlDocument();
    doc.LoadXml("<Employees9 />");
    using (XmlWriter writer = doc.DocumentElement.CreateNavigator().AppendChild())
    {
            foreach (Employee employee in employees)
            {
                writer.WriteStartElement("Employee");
                writer.WriteAttributeString("ID", employee.Id.ToString());
                writer.WriteAttributeString("FirstName", employee.FirstName);
                writer.WriteAttributeString("LastName", employee.LastName);
                writer.WriteAttributeString("Salary", employee.Salary.ToString());
                writer.WriteEndElement();
            }
            doc.Save(@"C:\Users\simonjef\Desktop\Account.xml"); 
    }
