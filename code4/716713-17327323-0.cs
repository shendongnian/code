    X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
    X509Certificate2 c = store.Certificates
        .Find(X509FindType.FindBySubjectName, SIGNED_SUBJECT, true) 
    	.Cast<X509Certificate2>()
    	.FirstOrDefault();
    	store.Close();
    
    RSACryptoServiceProvider rsa = c.PrivateKey as RSACryptoServiceProvider;
    Console.WriteLine("Certificate thumbprint:" + c.Thumbprint);
    Console.WriteLine("From machine key store?: " + rsa.CspKeyContainerInfo.MachineKeyStore);
    Console.WriteLine("Key container name: " + rsa.CspKeyContainerInfo.KeyContainerName);
    Console.WriteLine("Key unique container name: " + rsa.CspKeyContainerInfo.UniqueKeyContainerName);	
