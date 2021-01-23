    {
        const int PROV_DSS_DH = 13;
        var cspParameters = new CspParameters(PROV_DSS_DH);
        DSA dsa = new DSACryptoServiceProvider(1024, cspParameters);
        string publicPrivateKeyXML = dsa.ToXmlString(true);
        string publicOnlyKeyXML = dsa.ToXmlString(false);
    }
    {
        const int PROV_DSS_DH = 13;
        var cspParameters = new CspParameters(PROV_DSS_DH);
        cspParameters.Flags = CspProviderFlags.CreateEphemeralKey;
        DSA dsa = new DSACryptoServiceProvider(1024, cspParameters);
        string publicPrivateKeyXML = dsa.ToXmlString(true);
        string publicOnlyKeyXML = dsa.ToXmlString(false);
    }
    {
        DSA dsa = new DSACryptoServiceProvider(1024);
        string publicPrivateKeyXML = dsa.ToXmlString(true);
        string publicOnlyKeyXML = dsa.ToXmlString(false);
    }
