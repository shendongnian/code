    public void IssueClientFromCA()
    {
        // get CA
        string caCn = "MyCA CommonName";
        Stream caCertFile = File.OpenRead(string.Format(@"{0}\{1}", _certificatesDir, "MyCAFile.pfx"));
        char[] caPass = "passwordForThePfx".ToCharArray();
    
        Pkcs12Store store = new Pkcs12StoreBuilder().Build();
        store.Load(caCertFile, caPass);            
        var caCert = store.GetCertificate(caCn).Certificate;
        var caPrivKey = store.GetKey(caCn).Key;
    
        var clientCert = CertIssuer.GenerateDsaCertificateAsPkcs12(
            "My Client FriendlyName",
            "My Client SubjectName", 
            "GT",
            new DateTime(2011,9,19), 
            new DateTime(2014,9,18),
            "PFXPASS",
            caCert,
            caPrivKey);
    
        var saveAS = string.Format(@"{0}\{1}", _certificatesDir, "clientCertFile.pfx");
        File.WriteAllBytes(saveAS, clientCert);
    }
    
    public static byte[] GenerateDsaCertificateAsPkcs12(
        string friendlyName,
        string subjectName,
        string country,
        DateTime validStartDate,
        DateTime validEndDate,
        string password,
        Org.BouncyCastle.X509.X509Certificate caCert,
        AsymmetricKeyParameter caPrivateKey)
    {
        var keys = GenerateDsaKeys();
    
        #region build certificate
        var certGen = new X509V3CertificateGenerator();
    
        // build name attributes
        var nameOids = new ArrayList();
        nameOids.Add(Org.BouncyCastle.Asn1.X509.X509Name.CN);
        nameOids.Add(X509Name.O);
        nameOids.Add(X509Name.C);
    
        var nameValues = new ArrayList();
        nameValues.Add(friendlyName);
        nameValues.Add(subjectName);
        nameValues.Add(country);
        var subjectDN = new X509Name(nameOids, nameValues);
    
        // certificate fields
        certGen.SetSerialNumber(BigInteger.ValueOf(1));
        certGen.SetIssuerDN(caCert.SubjectDN);
        certGen.SetNotBefore(validStartDate);
        certGen.SetNotAfter(validEndDate);
        certGen.SetSubjectDN(subjectDN);
        certGen.SetPublicKey(keys.Public);
        certGen.SetSignatureAlgorithm("SHA1withDSA");
    
        // extended information
        certGen.AddExtension(X509Extensions.AuthorityKeyIdentifier, false, new AuthorityKeyIdentifierStructure(caCert.GetPublicKey()));
        certGen.AddExtension(X509Extensions.SubjectKeyIdentifier, false, new SubjectKeyIdentifierStructure(keys.Public));
        #endregion
    
        // generate x509 certificate
        var cert = certGen.Generate(caPrivateKey);
        //ert.Verify(caCert.GetPublicKey());
    
        var chain = new Dictionary<string, Org.BouncyCastle.X509.X509Certificate>();
        //chain.Add("CertiFirmas CA", caCert);
        var caCn = caCert.SubjectDN.GetValues(X509Name.CN)[0].ToString();
        chain.Add(caCn, caCert);
    
        // store the file
        return GeneratePkcs12(keys, cert, friendlyName, password, chain);
    }
    
    private static byte[] GeneratePkcs12(AsymmetricCipherKeyPair keys, Org.BouncyCastle.X509.X509Certificate cert, string friendlyName, string password,
        Dictionary<string, Org.BouncyCastle.X509.X509Certificate> chain)
    {
        var chainCerts = new List<X509CertificateEntry>();
    
        // Create the PKCS12 store
        Pkcs12Store store = new Pkcs12StoreBuilder().Build();
    
        // Add a Certificate entry
        X509CertificateEntry certEntry = new X509CertificateEntry(cert);
        store.SetCertificateEntry(friendlyName, certEntry); // use DN as the Alias.
        //chainCerts.Add(certEntry);
    
        // Add chain entries
        var additionalCertsAsBytes = new List<byte[]>();
        if (chain != null && chain.Count > 0)
        {
            foreach (var additionalCert in chain)
            {
                additionalCertsAsBytes.Add(additionalCert.Value.GetEncoded());
            }
        }
    
        if (chain != null && chain.Count > 0)
        {
            var addicionalCertsAsX09Chain = BuildCertificateChainBC(cert.GetEncoded(), additionalCertsAsBytes);
    
            foreach (var addCertAsX09 in addicionalCertsAsX09Chain)
            {
                chainCerts.Add(new X509CertificateEntry(addCertAsX09));
            }
        }
    
        // Add a key entry
        AsymmetricKeyEntry keyEntry = new AsymmetricKeyEntry(keys.Private);
                
        // no chain
        store.SetKeyEntry(friendlyName, keyEntry, new X509CertificateEntry[] { certEntry });
    
        using (var memoryStream = new MemoryStream())
        {
            store.Save(memoryStream, password.ToCharArray(), new SecureRandom());
            return memoryStream.ToArray();
        }
    }
