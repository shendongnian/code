    XmlDocument doc = new XmlDocument();
    string path = @"C:\Users\karansha\Desktop\config file 1.xml";
    doc.Load(path);
    foreach (XmlNode selectNode in doc.SelectNodes("/appSettings/property"))
    {
        if(selectNode.Attributes["name"].Value = "FTP_USER" ||
           selectNode.Attributes["name"].Value = "FTP_READ_USER")
        {
            selectNode.Attributes["value"].Value = "new_password";
        }
    }
    doc.Save(path); 
