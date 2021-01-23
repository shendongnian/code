    // Load the cert, many ways, one implementation
    var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
    var certs = store.Certificates.Find(X509FindType.FindBySubjectName, "My cert subject name", true);
    store.Close();
    if (certs.Count > 0)
        cert = certs[0];
    else
        return;
    // Magic happens here! We load the private CngKey (if it exists)
    // You need CLR Security for this, it manages the P/Invoke
    // into the C++ api behind the scenes. 
    var pvtCngKey = cert.GetCngPrivateKey(); 
    // Create the DiffieHellman helper
    var ecDh = new ECDiffieHellmanCng(ourPvtEcCngKey)
    {
       KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
       HashAlgorithm = CngAlgorithm.Sha256
    };
    ECDiffieHellmanCngPublicKey theirPubCngKey = LoadOtherPartiesCngPublicKey(theirCert);
    byte[] symKey = ecDh.DeriveKeyMaterial(theirPubCngKey);
