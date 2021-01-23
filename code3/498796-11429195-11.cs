    //where pemstring contains the certificate in a PEMstring like shown above.
    //and privateKey is the one we had in the first part over at the client.
    PemReader pr = new PemReader(new StringReader(pemstring));
    X509Certificate2 cert = DotNetUtilities.ToX509Certificate((Bouncy.X509Certificate)pr.ReadObject());
    CspParameters cparms = new CspParameters
    {
        CryptoKeySecurity = new CryptoKeySecurity(),
        Flags = CspProviderFlags.UseMachineKeyStore
    };
    RSACryptoServiceProvider rcsp = new RSACryptoServiceProvider(cparms);
    RSAParameters parms = new RSAParameters
    {
        Modulus = privateKey.Modulus.ToByteArrayUnsigned (),
        P = privateKey.P.ToByteArrayUnsigned (),
        Q = privateKey.Q.ToByteArrayUnsigned (),
        DP = privateKey.DP.ToByteArrayUnsigned (),
        DQ = privateKey.DQ.ToByteArrayUnsigned (),
        InverseQ = privateKey.QInv.ToByteArrayUnsigned (),
        D = privateKey.Exponent.ToByteArrayUnsigned (),
        Exponent = privateKey.PublicExponent.ToByteArrayUnsigned ()
    };
    rcsp.ImportParameters(parms);
    
    netcert.PrivateKey = rcsp;
