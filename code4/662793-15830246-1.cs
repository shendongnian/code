    BasicHttpBinding binding = new BasicHttpBinding()
    {
         MaxReceivedMessageSize = 64000000,
         MaxBufferSize = 64000000,
         MaxBufferPoolSize = 64000000,
    // .....
    };
    binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
    {
        MaxArrayLength = 64000000,
        MaxStringContentLength = 64000000,
        MaxDepth = 64000000,
        MaxBytesPerRead = 64000000
    };
