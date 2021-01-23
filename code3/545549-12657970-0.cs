    // Data to protect. Convert a string to a byte[] using Encoding.UTF8.GetBytes().
    byte[] plaintext; 
    // Generate additional entropy (will be used as the Initialization vector)
    byte[] entropy;
    using(RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
    {
        entropy = rng.GetBytes(20);
    }
    byte[] ciphertext = ProtectedData.Protect(plaintext, entropy,
        DataProtectionScope.CurrentUser);
