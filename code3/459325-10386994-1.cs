    class Program
    {
        static void Main(string[] args)
        {
            using (var serverManager = new ServerManager())
            {
                var selfSignedCnName = "TEST_SELF_SIGNED";
                var websiteName = "Default Web Site";
                var site = serverManager.Sites.Where(p => p.Name.ToLower() == websiteName.ToLower()).FirstOrDefault(); 
                var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadWrite);
                var certificate = store.Certificates.Find(X509FindType.FindByIssuerName, selfSignedCnName, true).OfType<X509Certificate>().FirstOrDefault();
                site.Bindings.Add("*:443:", certificate.GetCertHash(), store.Name);
                store.Close();
                serverManager.CommitChanges();
            }
        }
    }
