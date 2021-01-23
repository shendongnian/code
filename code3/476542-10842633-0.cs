    using (var ctx = new ImpersonationContext("svcAcctUserName", "domain", "password"))
    {
       var store = new X509Store(StoreLocation.LocalMachine);
       store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
       var clientCert = store.Certificates.Find(X509FindType.FindByIssuerName, "IssuerNameHere", false);
       var clientCert2 = new X509Certificate2(clientCert[0]);
    }
