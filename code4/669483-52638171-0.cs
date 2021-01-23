     public static string EncryptRsa(string stringPublicKey, string stringDataToEncrypt)
    {
        byte[] publicKey = Convert.FromBase64String(stringPublicKey);
        using (RSACryptoServiceProvider rsa = DecodeX509PublicKey(publicKey))
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(stringDataToEncrypt);
            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);
            return Convert.ToBase64String(encryptedData);
        }
    }
    public static RSACryptoServiceProvider DecodeX509PublicKey(byte[] x509key)
    {
        byte[] SeqOID = { 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01 };
        MemoryStream ms = new MemoryStream(x509key);
        BinaryReader reader = new BinaryReader(ms);
        if (reader.ReadByte() == 0x30)
            ReadASNLength(reader); //skip the size 
        else
            return null;
        int identifierSize = 0; //total length of Object Identifier section 
        if (reader.ReadByte() == 0x30)
            identifierSize = ReadASNLength(reader);
        else
            return null;
        if (reader.ReadByte() == 0x06) //is the next element an object identifier? 
        {
            int oidLength = ReadASNLength(reader);
            byte[] oidBytes = new byte[oidLength];
            reader.Read(oidBytes, 0, oidBytes.Length);
            if (oidBytes.SequenceEqual(SeqOID) == false) //is the object identifier rsaEncryption PKCS#1? 
                return null;
            int remainingBytes = identifierSize - 2 - oidBytes.Length;
            reader.ReadBytes(remainingBytes);
        }
        if (reader.ReadByte() == 0x03) //is the next element a bit string? 
        {
            ReadASNLength(reader); //skip the size 
            reader.ReadByte(); //skip unused bits indicator 
            if (reader.ReadByte() == 0x30)
            {
                ReadASNLength(reader); //skip the size 
                if (reader.ReadByte() == 0x02) //is it an integer? 
                {
                    int modulusSize = ReadASNLength(reader);
                    byte[] modulus = new byte[modulusSize];
                    reader.Read(modulus, 0, modulus.Length);
                    if (modulus[0] == 0x00) //strip off the first byte if it's 0 
                    {
                        byte[] tempModulus = new byte[modulus.Length - 1];
                        Array.Copy(modulus, 1, tempModulus, 0, modulus.Length - 1);
                        modulus = tempModulus;
                    }
                    if (reader.ReadByte() == 0x02) //is it an integer? 
                    {
                        int exponentSize = ReadASNLength(reader);
                        byte[] exponent = new byte[exponentSize];
                        reader.Read(exponent, 0, exponent.Length);
                        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024);
                        RSAParameters RSAKeyInfo = new RSAParameters();
                        RSAKeyInfo.Modulus = modulus;
                        RSAKeyInfo.Exponent = exponent;
                        RSA.ImportParameters(RSAKeyInfo);
                        return RSA;
                    }
                }
            }
        }
        return null;
    }
    public static int ReadASNLength(BinaryReader reader)
    {
        //Note: this method only reads lengths up to 4 bytes long as 
        //this is satisfactory for the majority of situations. 
        int length = reader.ReadByte();
        if ((length & 0x00000080) == 0x00000080) //is the length greater than 1 byte 
        {
            int count = length & 0x0000000f;
            byte[] lengthBytes = new byte[4];
            reader.Read(lengthBytes, 4 - count, count);
            Array.Reverse(lengthBytes); // 
            length = BitConverter.ToInt32(lengthBytes, 0);
        }
        return length;
    }
