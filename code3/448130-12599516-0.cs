    public void Foo()
    {
        //var uri = new Uri("http://kozhevnikov.com/foo.asmx?WSDL");
        //var uri = new Uri("http://kozhevnikov.com/bar.svc?WSDL");
        var importer = new WsdlImporter(new MetadataExchangeClient(uri, MetadataExchangeClientMode.HttpGet).GetMetadata());
        var version = importer.ImportAllEndpoints().Aggregate(Soap.None, (v, e) => v | Parse(e.Binding.MessageVersion.Envelope));
        if (version == Soap.None)
            Console.WriteLine("Is None.");
        if (version.HasFlag(Soap.Both))
            Console.WriteLine("Has Both.");
        Console.WriteLine(version);
    }
    private static Soap Parse(EnvelopeVersion version)
    {
        if (version == EnvelopeVersion.None)
            return Soap.None;
        if (version == EnvelopeVersion.Soap11)
            return Soap.Soap11;
        if (version == EnvelopeVersion.Soap12)
            return Soap.Soap12;
        throw new NotImplementedException(version.ToString());
    }
    public enum Soap
    {
        None,
        Soap11,
        Soap12,
        Both = Soap11 | Soap12
    }
