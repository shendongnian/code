    public string EncryptTripleDES(string Plaintext, string Key)
    {
        System.Security.Cryptography.TripleDESCryptoServiceProvider DES =
        new System.Security.Cryptography.TripleDESCryptoServiceProvider();
        System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 =
        new System.Security.Cryptography.MD5CryptoServiceProvider();
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(Key));
        DES.Mode = System.Security.Cryptography.CipherMode.ECB;
        System.Security.Cryptography.ICryptoTransform DESEncrypt = DES.CreateEncryptor();
        Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(Plaintext);
       string TripleDES = Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        return TripleDES;
    }
    //Decryption Method 
    public string DecryptTripleDES(string base64Text, string Key)
    {
        System.Security.Cryptography.TripleDESCryptoServiceProvider DES =
        new System.Security.Cryptography.TripleDESCryptoServiceProvider();
        System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 =
        new System.Security.Cryptography.MD5CryptoServiceProvider();
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(Key));
        DES.Mode = System.Security.Cryptography.CipherMode.ECB;
        System.Security.Cryptography.ICryptoTransform DESDecrypt = DES.CreateDecryptor();
        Buffer = Convert.FromBase64String(base64Text);
        string DecTripleDES = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
       return DecTripleDES;
    }
