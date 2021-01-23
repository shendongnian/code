    XmlNodeList nodeList = m_xmlDoc.DocumentElement.SelectNodes("person");
    foreach (XmlNode PersonNode in nodeList)
    {
        Employee ccontact = new Employee();
        ccontact.LastName = PersonNode["LastName"].InnerText;
        ccontact.FirstName = PersonNode["FirstName"].InnerText;
        ccontact.EmployeeNumber = PersonNode["Employee"].InnerText;
        this.AddContact(ccontact);
    }
