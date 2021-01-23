    private static string GetPersonResultXml()
    {
        var jobs = new Result<Person>();
        jobs.Items.Add(new Person() { Id = 1 });
        jobs.Items.Add(new Person() { Id = 2 });
    
        XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
        xmlnsEmpty.Add("", "");
    
        XmlWriterSettings xws = new XmlWriterSettings();
        xws.OmitXmlDeclaration = true;
        xws.ConformanceLevel = ConformanceLevel.Auto;
        xws.Indent = true;
    
        XmlAttributeOverrides overrides = new XmlAttributeOverrides();
        XmlAttributes attr = new XmlAttributes();
        attr.XmlRoot = new XmlRootAttribute("PersonResult");
        overrides.Add(jobs.GetType(), attr);
    
        XmlAttributes attr1 = new XmlAttributes();
        attr1.XmlElements.Add(new XmlElementAttribute("Person", typeof(Person)));
        overrides.Add(jobs.GetType(), "Items", attr1);
    
        StringBuilder xmlString = new StringBuilder();
        using (XmlWriter xtw = XmlTextWriter.Create(xmlString, xws))
        {
            XmlSerializer serializer = new XmlSerializer(jobs.GetType(), overrides);
            serializer.Serialize(xtw, jobs, xmlnsEmpty);
    
            xtw.Flush();
        }
    
        return xmlString.ToString();
    }
