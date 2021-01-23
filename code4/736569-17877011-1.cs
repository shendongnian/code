    public static string EncryptData(string encryptText)
    {
        return EncryptionHelper.EncryptData(encryptText, ConfigHelper.PassPhrase, ConfigHelper.SaltValue, ConfigHelper.HashAlgorithm, ConfigHelper.PasswordIterations, ConfigHelper.InitVector, ConfigHelper.KeySize);
    }
    public static string DecryptData(string decryptText)
    {
        return EncryptionHelper.DecryptData(decryptText, ConfigHelper.PassPhrase, ConfigHelper.SaltValue, ConfigHelper.HashAlgorithm, ConfigHelper.PasswordIterations, ConfigHelper.InitVector, ConfigHelper.KeySize);
    }
