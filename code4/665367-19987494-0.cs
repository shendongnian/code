    public void ProcessRequest(HttpContext context)
    {
         // a bunch of request handling logic
         //...
         HttpResponse response = context.Response;
         XmlDocument signedXML = getTheSignedXMLData(); //the XML
         signedXML.PreserveWhitespace = true;
         signedXML.Save(response.Output);
     }
