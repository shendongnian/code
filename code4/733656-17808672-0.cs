    var meta = new ServiceMetadataBehavior()
    {
        //ExternalMetadataLocation = new Uri(soapServerUrl + "/CritiMon?wsdl"),
        HttpGetEnabled = true,
        HttpGetUrl = new Uri("", UriKind.Relative),
        HttpGetBinding = basicHttpBinding,
    };
     host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
