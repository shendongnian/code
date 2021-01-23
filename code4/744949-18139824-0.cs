    XDocument xDoc = XDocument.Load("C:\\test.xml");
        if (xDoc != null)
        {
            IEnumerable<XElement> xEle = xDoc.XPathSelectElements("//property");
            if (xEle != null)
            {
               foreach (XElement xE in xEle)
                {
                    if (xE.Attribute("name") != null)
                    {
                       if(xE.Attribute("value") !=null)
                        {
                        if(string.compare(xE.Attribute("name").Value,"FTP_USER",true) ==0)
                           xE.Attribute("value").Value = "your new password"
                        if(string.compare(xE.Attribute("name").Value,"FTP_READ_USER",true) ==0)
                           xE.Attribute("value").Value = "your new password"
                         }
                        
                    }
                }
                xDoc.Save("C:\\test.xml");
            }
        }
