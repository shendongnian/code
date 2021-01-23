    public bool Save(string filename, object toSerialize)
        {
            byte[] SALT = new byte[]
            {0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c};
            string EncryptionKey = "MYPASSWORD";
            //basic serialization
            IFormatter form = new BinaryFormatter();
            var stream = new MemoryStream();
            form.Serialize(stream, toSerialize);
            //cryptography preparation
            var alg = new RijndaelManaged();
            var pdb = new Rfc2898DeriveBytes(EncryptionKey, SALT);
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);
            stream.Position = 0;
            //cryptorgraphy serialization
            var encStream = new MemoryStream();
            var cryptoStream = new CryptoStream(encStream, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(stream.ToArray(), 0, (int)stream.Length);
            cryptoStream.FlushFinalBlock();
            var outputFileStream = new FileStream(fileName, FileMode.Create);
            outputFileStream.Write(encStream.ToArray(), 0, (int)encStream.Length);
            outputFileStream.Close();
            return true;
        }
