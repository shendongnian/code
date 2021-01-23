    string test = "1";
    AES aes = new AES(System.Text.Encoding.UTF8);
    RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
    byte[] key = new byte[32];
    byte[] iv = new byte[32];
    
    // Generate random key and IV
    rngCsp.GetBytes(key);
    rngCsp.GetBytes(iv);
    string cipher = aes.Encrypt(test, key, iv);
    string plaintext = aes.Decrypt(cipher, key, iv);
    Response.Write(cipher + "<BR/>");
    Response.Write(plaintext);
