    public static string Encrypt(string PlainText, string Password, string Salt,
     string HashAlgorithm = "SHA1", int PasswordIterations = 16, string InitialVector = "Initial Vector", int KeySize = 256)
    {  
        byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
        byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
        byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
        PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
        byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
        RijndaelManaged SymmetricKey = new RijndaelManaged();
        SymmetricKey.Mode = CipherMode.CBC;
        ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes);
        MemoryStream MemStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
        cryptoStream.FlushFinalBlock();
        byte[] CipherTextBytes = MemStream.ToArray();
        MemStream.Close();
        cryptoStream.Close();
        Encryptor.Dispose();
        Encryptor = null;
        return Convert.ToBase64String(CipherTextBytes);
    }
    public static string Decrypt(string CipherText, string Password, string Salt,
        string HashAlgorithm = "SHA1", int PasswordIterations = 16, string InitialVector = "Initial Vector", int KeySize = 256)
    { 
        byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
        byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
        byte[] CipherTextBytes = Convert.FromBase64String(CipherText);
        PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
        byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
        RijndaelManaged SymmetricKey = new RijndaelManaged();
        SymmetricKey.Mode = CipherMode.CBC;
        ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes);
        MemoryStream MemStream = new MemoryStream(CipherTextBytes);
        CryptoStream cryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read);
        byte[] PlainTextBytes = new byte[CipherTextBytes.Length];
        int ByteCount = cryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
        MemStream.Close();
        cryptoStream.Close();
        Decryptor.Dispose();
        Decryptor = null;
        return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount);
    }
