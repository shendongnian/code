    public void WriteXML()
    {
        Book overview = new Book();
        overview.title = "Serialization Overview";
        System.Xml.Serialization.XmlSerializer writer = 
            new System.Xml.Serialization.XmlSerializer(typeof(Book));
    
        System.IO.StreamWriter file = new System.IO.StreamWriter(
            @"c:\temp\SerializationOverview.xml");
        writer.Serialize(file, overview);
        file.Close();
    }
