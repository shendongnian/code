    [WebMethod]
    public string HelloWorld()
    {
        var doc = new XmlDocument();
        var node = doc.CreateNode(
            XmlNodeType.Element, 
            SoapException.DetailElementName.Name, 
            SoapException.DetailElementName.Namespace
        );
        // you could actually use any sub nodes here
        // and pass even complex objects
        node.InnerText = "no files found";
        throw new SoapException(
            "Fault occurred", 
            SoapException.ClientFaultCode, 
            Context.Request.Url.AbsoluteUri, 
            node
        );
    }
