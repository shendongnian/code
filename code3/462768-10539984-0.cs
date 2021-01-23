    void Main()
    {
        var data = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        var key = new byte[] { 01, 12, 23, 34, 45, 56, 67, 78, 89, 90, 09, 98, 87, 76, 65, 54, 43, 32, 21, 10, 11, 22, 33, 44 };
        var encrypted = Encrypt(data, key, 0);
        Console.WriteLine(encrypted);
        var decrypted = Decrypt(encrypted, key, 0);
        // decrypted should be equal to data here
    }
    
    public string Encrypt(byte[] data, byte[] key, long nonce)
    {
        return Convert.ToBase64String(Transform(data, key, nonce));
    }
    
    public byte[] Decrypt(string data, byte[] key, long nonce)
    {
        return Transform(Convert.FromBase64String(data), key, nonce);
    }
    
    byte[] Transform(byte[] data, byte[] key, long nonce)
    {
        if (data.Length > 96/8) throw new ArgumentException("Too much data");
    
        using (var des = new TripleDESCryptoServiceProvider())
        {
            des.Key = key;
            des.Mode = CipherMode.ECB;
            using (var encryptor = des.CreateEncryptor())
            {
                var output = new byte[data.Length];
                var offset = 0;
                for(int counter = 0; counter <= data.Length / 8; ++counter)
                {
                    var counterData = BitConverter.GetBytes(((long)counter) ^ nonce);
                    var counterEncryption = new byte[des.BlockSize / 8];
                    var counterEncryptionLen = encryptor.TransformBlock(counterData, 0, counterData.Length, counterEncryption, 0);
                    Debug.Assert(counterEncryptionLen == counterEncryption.Length);
                    for (var i = 0; i < des.BlockSize / 8 && offset < output.Length; ++i, ++offset)
                    {
                        output[offset] = (byte)(data[offset] ^ counterEncryption[i]);
                    }
                }
                return output;
            }
        }
    }
