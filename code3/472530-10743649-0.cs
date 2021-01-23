    public static byte[] RetrieveIv(string encryptedBase64)
    {
        // We don't need to base64-decode everything... just 16 bytes-worth
        encryptedBase64 = encryptedBase64.Substring(0, 24);
        // This will be 18 bytes long (4 characters per 3 bytes)
        byte[] encryptedBinary = Convert.FromBase64String(encryptedBase64);
        byte[] iv = new byte[16];
        
        Array.Copy(encryptedBinary, 0, iv, 0, 16);
        return iv;
    }
