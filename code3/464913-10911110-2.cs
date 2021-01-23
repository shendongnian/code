    var managedCert = new System.Security.Cryptography.X509Certificates.X509Certificate2(serverCertificate.DER);
    var chain = new System.Security.Cryptography.X509Certificates.X509Chain();
    chain.Build(managedCert);
    foreach (var element in chain.ChainElements)
    {
        var raw = element.Certificate.RawData;
        using (var bio = new BIO(raw))
        {
            var oc = OpenSSL.X509.X509Certificate.FromDER(bio);
        }
    }
