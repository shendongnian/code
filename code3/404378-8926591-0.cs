    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
    FileStream fs = new FileStream("whatever.xml", FileMode.Create);
    
    XmlWriter writer = XmlWriter.Create(fs);
    
                
    writer.WriteRaw("<rootEl>");
    writer.WriteRaw("<rootEl />");
                
    writer.Flush();
    fs.Close();
