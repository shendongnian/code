    XDocument Xdoc = new XDocument(new XElement("Users"));
            if (System.IO.File.Exists("D:\\Users.xml"))
                Xdoc = XDocument.Load("D:\\Users.xml");
            else
                Xdoc = new XDocument();
    
           XElement xml = /*new XElement("Users",*/
                           new XElement("User",
                           new XElement("UserId", "sunny"),
                           new XElement("Password", "pwd")
                           );
    
            if (Xdoc.Descendants().Count() > 0)
                Xdoc.Descendants().First().Add(xml);
            else
            {
                Xdoc.Add(xml);
            }
    
            Xdoc.Save("D:\\Users.xml");
