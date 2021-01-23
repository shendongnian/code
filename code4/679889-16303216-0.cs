    XmlDocument XmlFoo = null;
    
    try
    {
        XmlFoo = new XmlDocument();
        XmlFoo.LoadXml(SomeXml);
    }
    (XmlException ex)
    {
    	// Loadxml went wrong
    }
    (Exception ex)
    {
    	// Some other Error
    }
