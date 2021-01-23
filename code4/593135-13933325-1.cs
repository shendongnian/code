    string vParameter = "Lq4aURUiyvKvEZBWMWpUr2wRSMu96E+J1UeHLTOhKEM="; //v parameter
    byte[] encryptedV = Convert.FromBase64String(vParameter);
    string salt = "jkjkyt4"; // the i parameter - user’s id
    string password = "^hjkh673!v@!a89mz+%5rT"; // application specific
    var sha1 = SHA1Managed.Create();
    byte[] keyBytes = Encoding.UTF8.GetBytes(salt + password); //salt + password
    byte[] key = sha1.ComputeHash(keyBytes);
    byte[] finalKey = { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };
    string appIV = "SampleIV12345678";
    byte[] iv = Encoding.UTF8.GetBytes(appIV); //iv
    Array.Copy(key, 2, finalKey, 0, 16); //key 2, 16
    AesManaged aes = new AesManaged();
    aes.Key = finalKey;
    aes.Mode = CipherMode.CBC;
    aes.Padding = PaddingMode.PKCS7;
    aes.IV = iv;
    ICryptoTransform crypt = aes.CreateDecryptor();
    byte[] cipher = crypt.TransformFinalBlock(encryptedV, 0, encryptedV.Length);
    string decryptedText = Encoding.UTF8.GetString(cipher);
    Console.WriteLine(decryptedText); // foobarfoobarfoobarfoobarfoobar
