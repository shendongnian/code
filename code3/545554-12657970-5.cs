    // Data to protect. Convert a string to a byte[] using Encoding.UTF8.GetBytes().
    byte[] plaintext; 
    // Generate additional entropy (will be used as the Initialization vector)
    byte[] entropy = new byte[20];
    using(RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
    {
        rng.GetBytes(entropy);
    }
    byte[] ciphertext = ProtectedData.Protect(plaintext, entropy,
        DataProtectionScope.CurrentUser);
