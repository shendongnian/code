    string input = "test";
    string output = string.Empty;
    X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
    store.Open(OpenFlags.ReadOnly);
    X509Certificate2Collection collection = store.Certificates.Find(X509FindType.FindBySubjectName, "MyCertificate", false);
    X509Certificate2 certificate = collection[0];
    using (RSACryptoServiceProvider cps = (RSACryptoServiceProvider)certificate.PublicKey.Key)
    {
        byte[] bytesData = Encoding.UTF8.GetBytes(input);
        byte[] bytesEncrypted = cps.Encrypt(bytesData, false);
        output = Convert.ToBase64String(bytesEncrypted);
    }
    store.Close();
