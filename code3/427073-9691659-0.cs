    using cryptlib;
    byte[] key = new byte[16] {...key bytes here...};
    byte[] iv =  new byte[16] {...iv bytes here...};
    byte[] enc;  //encoded bytes (i populated them from a filestream)
    crypt.Init();
    int cryptContext = crypt.CreateContext(crypt.UNUSED, crypt.ALGO_AES);
    crypt.SetAttribute(cryptContext, crypt.CTXINFO_MODE, crypt.MODE_CFB);
    crypt.SetAttributeString(cryptContext, crypt.CTXINFO_KEY, key, 0, 16);
    crypt.SetAttributeString(cryptContext, crypt.CTXINFO_IV, iv, 0, 16);
    crypt.Decrypt(cryptContext, enc);   //ciphertext bytes replaced with plaintext bytes
    crypt.DestroyContext(cryptContext);
