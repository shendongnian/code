    XDocument xdoc = new XDocument();
    xdoc = XDocument.Load(fileName);
    var songlist = from c in xdoc.Element("Result").Elements("email")
                               select new eMail{ 
                                   ID = c.Element("ID").Value, 
                                   Subject = c.Element("Subject").Value };
