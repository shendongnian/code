    // First File
    var xmlStream = System.Web.HttpContext.Current.Request.Files[0].InputStream;
    var xmlDocument = new XmlDocument();
    xmlDocument.Load(xmlStream);
    // The same code for the second file processing.
    // ...
