    static void o(string s, params object[] args)
    {
        Console.WriteLine(s, args);
    }
    
    static void CertList()
    {
        X509Store store = new X509Store(StoreName.My,  StoreLocation.CurrentUser);
        store.Open(OpenFlags.ReadOnly);
        foreach (X509Certificate2 certificate in store.Certificates)
        {
            o("");
            o("Friendly Name: {0}", certificate.FriendlyName);
            o("Simple Name:   {0}", 
               certificate.GetNameInfo(X509NameType.SimpleName, true));
            o("Issuer:        {0}", certificate.Issuer);
            o("Expiration:    {0}", certificate.NotAfter);
    
            //  http://msdn.microsoft.com/en-us/library/system.security.cryptography.x509certificates.x509keyusageextension.aspx
            foreach (X509Extension extension in certificate.Extensions)
            {
                o(" {0}  ({1})", extension.Oid.FriendlyName, extension.Oid.Value);
    
                if (extension.Oid.Value == "2.5.29.15")
                //  if (extension.Oid.FriendlyName == "Key Usage")
                {
                    X509KeyUsageExtension ext = (X509KeyUsageExtension)extension;
                    o("Key usages:          {0}", ext.KeyUsages);
                }
                else if (extension.Oid.Value == "2.5.29.37")
                //  if (extension.Oid.FriendlyName == "Extended Key Usage")
                {
                    X509EnhancedKeyUsageExtension ext =
                                       (X509EnhancedKeyUsageExtension)extension;
                    o("Extended Key usages: {0}", ext.EnhancedKeyUsages);
                }
            }
        }
        store.Close();
    }
