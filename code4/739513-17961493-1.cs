    XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
    
    while (xmlReader.Read())
    {
        if (xmlReader.Name.Equals("Time") && (xmlReader.NodeType == XmlNodeType.Element))
        {
            Console.WriteLine(DateTime.Parse((string)xmlReader.ReadElementContentAs(typeof(string), null), CultureInfo.InvariantCulture));
        }                
    }
