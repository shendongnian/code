    // First file
    var xmlStream = System.Web.HttpContext.Current.Request.Files[0].InputStream;
    var xmlDocument = new XmlDocument();
    xmlDocument.Load(xmlStream);
    // The same code for the second file processing.
    // Second file
    var wordDocStream = System.Web.HttpContext.Current.Request.Files[1].InputStream;
    var wordXmlDocument = new XmlDocument();
    wordXmlDocument.Load(wordDocStream);
