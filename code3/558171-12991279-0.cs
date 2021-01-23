    int flightCount = 0;
    using (XmlReader xmlReader = new XmlTextReader(new StringReader(text)))
    {
        while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element &&
                xmlReader.Name.Equals("Flight"))
            {
                flightCount++;
            }            
        }
    }
