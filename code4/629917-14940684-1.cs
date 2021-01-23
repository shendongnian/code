      using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
        {
            aesProvider.Key = key;
            aesProvider.Mode = CipherMode.CBC;
            aesProvider.Padding = PaddingMode.PKCS7;
            using (MemoryStream memStream = new MemoryStream())
            {
                /***change***/
                using(CryptoStream encStream = new CryptoStream(memStream, aesProvider.CreateEncryptor(), CryptoStreamMode.Write)){
                    encStream.Write(rawData, 0, rawData.Length);
                }
                /***end change**/
                EncryptResult encResult = new EncryptResult();
                encResult.EncryptedMsg = Convert.ToBase64String(memStream.ToArray());
                encResult.IV = Convert.ToBase64String(aesProvider.IV);
                return encResult;
            }
        }
