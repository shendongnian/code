     private static IBuffer GetMD5Hash(string key)
        {
            IBuffer bufferUTF8Msg = CryptographicBuffer.ConvertStringToBinary(key, BinaryStringEncoding.Utf8);
            HashAlgorithmProvider hashAlgorithmProvider = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            IBuffer hashBuffer = hashAlgorithmProvider.HashData(bufferUTF8Msg);
            if (hashBuffer.Length != hashAlgorithmProvider.HashLength)
            {
                throw new Exception("There was an error creating the hash");
            }
            return hashBuffer;
        }
        #region Static
       
        public static string GenerateKey(string password, int resultKeyLength = 68)
        {
            if (password.Length < 6)
                throw new ArgumentException("password length must atleast 6 characters or above");
            string key = "";
            var hashKey = GetMD5Hash(password);
            var decryptBuffer = CryptographicBuffer.ConvertStringToBinary(password, BinaryStringEncoding.Utf8);
            var AES = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7);
            var symmetricKey = AES.CreateSymmetricKey(hashKey);
            var encryptedBuffer = CryptographicEngine.Encrypt(symmetricKey, decryptBuffer, null);
            key = CryptographicBuffer.EncodeToBase64String(encryptedBuffer);
            string cleanKey  = key.Trim(new char[] { ' ', '\r', '\t', '\n', '/', '+', '=' });
            cleanKey = cleanKey.Replace("/", string.Empty).Replace("+", string.Empty).Replace("=", string.Empty);
            key = cleanKey;
            if(key.Length > resultKeyLength)
            {
               key = key.Substring(0, Math.Min(key.Length, resultKeyLength));
            }
            else if(key.Length == resultKeyLength)
            {
                return key;
            }
            else if (key.Length < resultKeyLength)
            {
                key = GenerateKey(key);
            }
            return key;
        }
