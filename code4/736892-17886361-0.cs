    string filePath = "C:/myFilePath";
    XmlDocument doc = new XmlDocument();
    if (System.IO.File.Exists(filePath))
    {
        doc.Load(filePath);
    }
    else
    {
        using (XmlWriter xWriter = XmlWriter.Create(filePath))
        {
            xWriter.WriteStartDocument();
            xWriter.WriteStartElement("Element Name");
            xWriter.WriteEndElement();
            xWriter.WriteEndDocument();
        }
        
        //OR
    
        XmlDeclaration xdec = doc.CreateXmlDeclaration("1.0", null, null);
        XmlComment xcom = doc.CreateComment("This file contains all the apps, versions, source and destination paths.");
        XmlNode newApp = doc.CreateElement("applications");
        XmlNode newApp = doc.CreateElement("applications1");
        XmlNode newApp = doc.CreateElement("applications2"); 
        doc.Save(filePath); //save a copy
    }
