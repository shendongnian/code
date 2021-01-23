     public static RSACryptoServiceProvider GetRsaProviderFromCertificate()
     {
         X509Store store = new X509Store(StoreLocation.LocalMachine);
         store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
         X509Certificate2Collection certCollection =  (X509Certificate2Collection)store.Certificates;
    
         foreach(X509Certificate2 cert in certCollection)
         {
             if (cert.SubjectName.Name.IndexOf("TheCertIWantToUse") > 0)
             {
                  return cert.PrivateKey as RSACryptoServiceProvider;
             }
         }
