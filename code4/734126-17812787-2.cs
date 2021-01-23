    System.Xml.XmlDocument xd = new XmlDocument();
    xd.Load(@"filepath");
    
    foreach(XmlNode nameNode in xd.GetElementsByTagName("name"))
    {
        if(nameNode.ParentNode.Name == "type1")
        {
            string currentNameValue = nameNode.InnerText;
            int cnvLen = currentNameValue.Length;
            string cnvWOdate = currentNameValue.Substring(0,cnvLen-8);
            string newNameValue = cnvWOdate+currTimeDate;
            
            nameNode.InnerText = newNameValue;
        }
    }
    
    xd.Save(@"newFilePath");
