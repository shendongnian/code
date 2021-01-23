    var key = new Rfc2898DeriveBytes("test password", Encoding.Unicode.GetBytes("test salt"));
    var provider = new RijndaelManaged { Padding = PaddingMode.PKCS7, KeySize = 256 };
    var keyBytes = key.GetBytes(provider.KeySize >> 3);
    var ivBytes = key.GetBytes(provider.BlockSize >> 3);
    var encryptor = provider.CreateEncryptor(keyBytes, ivBytes);
    var decryptor = provider.CreateDecryptor(keyBytes, ivBytes);
    
    var testStringBytes = Encoding.Unicode.GetBytes("test string");
    var testStringEncrypted = Convert.ToBase64String(encryptor.TransformFinalBlock(testStringBytes, 0, testStringBytes.Length));
    
    //Prove that the encryption has resulted in the following string
    Console.WriteLine(testStringEncrypted == "cc1zurZinx4yxeSB0XDzVziEUNJlFXsLzD2p9TWnxEc="); //Result: True
    
    //Decrypt the encrypted text from a hardcoded string literal
    var encryptedBytes = Convert.FromBase64String("cc1zurZinx4yxeSB0XDzVziEUNJlFXsLzD2p9TWnxEc=");
    
    var testStringDecrypted = Encoding.Unicode.GetString(decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
    
    //Decrypt the encrypted text from the string result of the encryption process
    var encryptedBytes2 = Convert.FromBase64String(testStringEncrypted);
    
    var testStringDecrypted2 = Encoding.Unicode.GetString(decryptor.TransformFinalBlock(encryptedBytes2, 0, encryptedBytes2.Length));
    
    //encryptedBytes and encryptedBytes2 should be identical, so they should result in the same decrypted text - but they don't: 
    Console.WriteLine(testStringDecrypted == "test string"); //Result: True
    Console.WriteLine(testStringDecrypted2 == "test string"); //Result: True
                
    Console.Read();
