    XDocument Xdoc = new XDocument(new XElement("Users"));
            if (System.IO.File.Exists("D:\\Users.xml"))
                Xdoc = XDocument.Load("D:\\Users.xml");
            else
            {
                Xdoc = new XDocument();
                XElement xmlstart = new XElement("Users");
                Xdoc.Add(xmlstart);
            }
            XElement xml = /*new XElement("Users",*/
                           new XElement("User",
              new XElement("UserId", txtUserId.Text),
              new XElement("Password", txtPwd.Text));
            if (Xdoc.Descendants().Count() > 0)
                Xdoc.Descendants().First().Add(xml);
            else
            {
                Xdoc.Add(xml);
            }
            Xdoc.Element("Users").Save("D:\\Users.xml");
