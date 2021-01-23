    @using System.Xml.Linq
    @{
        var file = XmlDocument.Load(Server.MapPath(@"/App_Code/Test.xml"));
        var results = file.SelectNodes("someNode/*");
           select new { Name = e.Element("someValue").Value, Sales = e.Element("someValueTwo").Value };
        /*Do something with each node*/
        foreach(XmlNode aNode in results)
        {
           string value = aNode.InnerText
        }
    }
