    [WebMethod]
    public string sendXliff()
    {
        XmlDocument xmldoc = new XmlDocument();
        //if (Request.InputStream != null)
        if(HttpContext.Current.Request.InputStream!=null)
        {
            StreamReader stream = new StreamReader(HttpContext.Current.Request.InputStream);
            string xmls = stream.ReadToEnd();  // added to view content of input stream
            //XDocument xmlInput = XDocument.Parse(xmls);
            xmldoc.LoadXml(xmls);
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, "XSD LOCATION");
            settings.ValidationType = ValidationType.Schema;
            XmlReader rdr = XmlReader.Create(new StringReader(xmldoc.InnerXml), settings);
            while (rdr.Read()) { }
        }
        try
        {
            XmlNodeList xmlnode = xmldoc.GetElementsByTagName("ID");
            var sid = xmlnode[0].FirstChild.Value;
        }
        catch (Exception ex)
        {
        }
        
        return "OK";
    }
