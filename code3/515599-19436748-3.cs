    [HttpGet]
    public BinaryImage Single(int key)
    {
        //limit properties that are sent on wire for this request specifically
        var contractResolver = Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver as PublicDomainJsonContractResolverOptIn;
        if (contractResolver != null)
            contractResolver.AllowList = new string[] { "Id", "Bytes", "MimeType", "Width", "Height" };
        BinaryImage image = new BinaryImage { Id = 1 };
        //etc. etc.
        return image;
    }
