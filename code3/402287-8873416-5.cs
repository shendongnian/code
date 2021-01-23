    private static object thLockMe = new object();
    public string XmlString { get; set; }
    public ParserClass(string xmlString)
    {
        XmlString = xmlString;
    }
    public void ProcessXML()
    {
        XDocument reader = XDocument.Parse(xmlString);
        // some more code which doesn't need to access the shared resource
        lock (thLockMe)
        {
            // the necessary code to access the shared resource (and only that)
        }
        // more code
    }
