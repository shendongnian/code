    static IEnumerable<Org.BouncyCastle.X509.X509Certificate> BuildCertificateChainBC(byte[] primary, IEnumerable<byte[]> additional)
    {
        X509CertificateParser parser = new X509CertificateParser();
        PkixCertPathBuilder builder = new PkixCertPathBuilder();
    
        // Separate root from itermediate
        var intermediateCerts = new List<Org.BouncyCastle.X509.X509Certificate>();
        HashSet rootCerts = new HashSet();
    
        foreach (byte[] cert in additional)
        {
            var x509Cert = parser.ReadCertificate(cert);
    
            // Separate root and subordinate certificates
            if (x509Cert.IssuerDN.Equivalent(x509Cert.SubjectDN))
                rootCerts.Add(new TrustAnchor(x509Cert, null));
            else
                intermediateCerts.Add(x509Cert);
        }
    
        // Create chain for this certificate
        X509CertStoreSelector holder = new X509CertStoreSelector();
        holder.Certificate = parser.ReadCertificate(primary);
    
        // WITHOUT THIS LINE BUILDER CANNOT BEGIN BUILDING THE CHAIN
        intermediateCerts.Add(holder.Certificate);
    
        PkixBuilderParameters builderParams = new PkixBuilderParameters(rootCerts, holder);
        builderParams.IsRevocationEnabled = false;
    
        X509CollectionStoreParameters intermediateStoreParameters =
            new X509CollectionStoreParameters(intermediateCerts);
    
        builderParams.AddStore(X509StoreFactory.Create(
            "Certificate/Collection", intermediateStoreParameters));
    
        PkixCertPathBuilderResult result = builder.Build(builderParams);
    
        return result.CertPath.Certificates.Cast<Org.BouncyCastle.X509.X509Certificate>();
    }
    
    private static AsymmetricCipherKeyPair GenerateDsaKeys()
    {
        DSACryptoServiceProvider DSA = new DSACryptoServiceProvider();
        var dsaParams = DSA.ExportParameters(true);
        AsymmetricCipherKeyPair keys = DotNetUtilities.GetDsaKeyPair(dsaParams);
        return keys;
    }
