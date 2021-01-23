    var url = "www.that-website.com/foo/";
    var myRequest = (HttpWebRequest)WebRequest.Create(url);
    myRequest.Method = "GET";
    WebResponse myResponse = myRequest.GetResponse();                
    var responseStream = myResponse.GetResponseStream();
    var sr = new StreamReader(responseStream, Encoding.Default);
    var reader = new SgmlReader
                 {
                     DocType = "HTML",
                     WhitespaceHandling = WhitespaceHandling.None,
                     CaseFolding = CaseFolding.ToLower,
                     InputStream = sr
                 };
    var xmlDoc = new XmlDocument();
    xmlDoc.Load(reader);
    var nodeReader = new XmlNodeReader(xmlDoc);
    XElement xml = XElement.Load(nodeReader); 
