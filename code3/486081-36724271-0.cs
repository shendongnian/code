        var cspParameters = new CspParameters(13); // 13 = PROV_DSS_DH which is not exported
        cspParameters.Flags = CspProviderFlags.CreateEphemeralKey;
        DSA dsa = new DSACryptoServiceProvider(1024, cspParameters); // Generate a new 2048 bit RSA key
        string publicPrivateKeyXML = dsa.ToXmlString(true);
        string publicOnlyKeyXML = dsa.ToXmlString(false);
