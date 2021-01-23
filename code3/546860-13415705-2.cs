        private static string EncryptForOracle(string message, string key)
        {
            string iv = "0123456789ABCDEF";
            int lengthOfPaddedString;
            message = PadMessageWithCustomChar(message, out lengthOfPaddedString);
            byte[] textBytes = new byte[lengthOfPaddedString];
            textBytes = ASCIIEncoding.ASCII.GetBytes(message);
            byte[] keyBytes = new byte[key.Length];
            keyBytes = ASCIIEncoding.ASCII.GetBytes(key);
            byte[] ivBytes = new byte[iv.Length];
            ivBytes = StringUtilities.HexStringToByteArray(iv);
            byte[] encrptedBytes = Encrypt(textBytes, keyBytes, ivBytes);
            return StringUtilities.ByteArrayToHexString(encrptedBytes);
        }
        /// <summary>
        // On the Oracle side, our DBAs wrapped the call to the toolkit encrytion function to pad with a ~, I don't recommend
        // doing down this path, it is prone to error.
        // we are working with blocks of size 8 bytes, this method pads the last block with ~ characters.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="lengthOfPaddedString"></param>
        /// <returns></returns>
        private static string PadMessageWithCustomChar(string message, out int lengthOfPaddedString)
        {
            int lengthOfData = message.Length;
            int units;
            if ((lengthOfData % 8) != 0)
            {
                units = (lengthOfData / 8) + 1;
            }
            else
            {
                units = lengthOfData / 8;
            }
            lengthOfPaddedString = units * 8;
            message = message.PadRight(lengthOfPaddedString, '~');
            return message;
        }
        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            // Create a symmetric algorithm.
            TripleDES alg = TripleDES.Create();
            alg.Padding = PaddingMode.None;
            // You should be able to specify ANSIX923 in a normal implementation 
            // We have to use none because of the DBA's wrapper
            //alg.Padding = PaddingMode.ANSIX923;
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }
