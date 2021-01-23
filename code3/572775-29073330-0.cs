    public static X509Certificate2 Find(string issuer, string subject)
    {
        var certStore = new X509Store (StoreName.My, StoreLocation.CurrentUser);
        certStore.Open (OpenFlags.ReadOnly);
        var certCollection = certStore.Certificates.Find (X509FindType.FindByIssuerName, issuer, true);
        
        foreach (var cert in certCollection)
        {
            if (cert.FriendlyName == subject)
            {
                return cert;
            }
        }
        return null;
    }
