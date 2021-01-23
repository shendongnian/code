    byte[] derKeyBytes = File.ReadAllBytes("text.der"); // read in the binary file
    
    // Decode the public key component
    AsymmetricKeyParameter publicKey =
        PublicKeyFactory.CreateKey(derKeyBytes);
