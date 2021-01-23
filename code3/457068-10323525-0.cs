    public static void EncryptFile(string input, string output)
    {
        string theKey = "urKey";
        byte[] salt = new byte[] { 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c };
        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(theKey, salt);
        RijndaelManaged RMCrypto = new RijndaelManaged();
        using (var inputStream=new FileStream(input))
            using (var outputStream = new FileStream(output))
                using (CryptoStream cs = new CryptoStream(inputStream, RMCrypto.CreateEncryptor(pdb.GetBytes(32), pdb.GetBytes(16)), CryptoStreamMode.Read))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    do
                    {
                        bytesRead = cs.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead > 0);
                }
    }
