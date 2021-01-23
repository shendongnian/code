    var cert = new X509Certificate2(pathToCert, password);
    
    X509Chain chain = new X509Chain();
    chain.Build(cert);
    for (int i = 0; i < chain.ChainElements.Count; i++)
    {
       //add to the appropriate store
    }
