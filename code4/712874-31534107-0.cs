    // Iterate localmachine personal store
    X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    store.Open(OpenFlags.ReadOnly);
    foreach (var cert in store.Certificates)
    {
        string s = String.Format("{0} ({1})", 
          cert.GetNameInfo(X509NameType.SimpleName, false), 
          cert.GetNameInfo(X509NameType.SimpleName, true)); 
        System.Console.WriteLine(s);
    }
    store.close();
