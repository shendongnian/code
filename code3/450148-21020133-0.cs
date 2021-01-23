    void ReadXMLFile()
    {
    XmlTextReader reader = new XmlTextReader("ClassRoll.xml");
    reader.Read();
    while (reader.Read())
    {
        if (reader.Name == "id")
        {
             reader.Read();
             if(reader.NodeType == XmlNodeType.Text)
             {
               id = reader.Value;
               reader.Read();
             }
             
        }
     }
}
