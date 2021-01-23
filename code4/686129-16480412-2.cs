    // Export public key (on the encrypting end)
                publicKey = rsaProvider.ToXmlString(false);
    // Write public key to file
                publicKeyFile = File.CreateText(publicKeyFileName);
                publicKeyFile.Write(publicKey);   
