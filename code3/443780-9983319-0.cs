    //Function for encrypting propose
    static string SymmetricEncryption(string str, byte[] key, byte[] IV)
    {
    
    MemoryStream ms = new MemoryStream();
    
    try
    {
    
    //---creates a new instance of the RijndaelManaged class---
    RijndaelManaged RMCrypto = new RijndaelManaged();
    
    //---creates a new instance of the CryptoStream class---
    CryptoStream cryptStream =new CryptoStream(ms, RMCrypto.CreateEncryptor(key, IV),
    
    CryptoStreamMode.Write);
    
    StreamWriter sWriter = new StreamWriter(cryptStream);
    
    //---encrypting the string---
    sWriter.Write(str);
    
    sWriter.Close();
    
    cryptStream.Close();
    
    //---return the encrypted data as a string---
    return System.Convert.ToBase64String(ms.ToArray());
    
    }
    catch (Exception ex)
    
    {
    Console.WriteLine(ex.ToString());
    
    return (String.Empty);
    }
    
    }
     
     
    //Function for Decrypting propose
    static string SymmetricDecryption(string str, byte[] key, byte[] IV)
    {
    
    try
    
    {
    
    //---converts the encrypted string into a byte array---
    byte[] b = System.Convert.FromBase64String(str);
    
    //---converts the byte array into a memory stream for decryption---
    MemoryStream ms = new MemoryStream(b);
    
    //---creates a new instance of the RijndaelManaged class---
    RijndaelManaged RMCrypto = new RijndaelManaged();
    
    //---creates a new instance of the CryptoStream class---
    CryptoStream cryptStream = new CryptoStream(ms, RMCrypto.CreateDecryptor(key, IV),
    
    CryptoStreamMode.Read);
    
    //---decrypting the stream---
    StreamReader sReader = new StreamReader(cryptStream);
    
    //---converts the decrypted stream into a string---
    String s = sReader.ReadToEnd();
    
    sReader.Close();
    
    return s;
    
    }
    catch (Exception ex)
    {
    
    Console.WriteLine(ex.ToString());
    
    return String.Empty;
    
    }
     
    }
     
    
    
    //Main function execute the functions
    RijndaelManaged RMCrypto = new RijndaelManaged();
    
    //---generate key---
    RMCrypto.GenerateKey();
    
    byte[] key = RMCrypto.Key;
    
    Console.WriteLine(“Key : “ + System.Convert.ToBase64String(key));
    
    //---generate IV---
    RMCrypto.GenerateIV();
    
    byte[] IV = RMCrypto.IV;
    Console.WriteLine(“IV : “ + System.Convert.ToBase64String(IV));
     
    //---encrypt the string---
    string cipherText = SymmetricEncryption(“This is a test string.”, key, IV);
    
    Console.WriteLine(“Ciphertext: “ + cipherText);
    
    //---decrypt the string---
    Console.WriteLine(“Original string: “ + SymmetricDecryption(cipherText, key, IV));
