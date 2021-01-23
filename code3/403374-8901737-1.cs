    using (var client = new WebService1())
    {
        try
        {
            var result = client.HelloWorld();
        }
        catch (SoapException ex)
        {
            var detail = ex.Detail;
            // detail.InnerText will contain the detail message
            // as detail is an XmlNode if on the server you have
            // provided a complex XML you would be able to fetch it here
        }
    }
