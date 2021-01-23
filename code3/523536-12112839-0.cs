        private string decipher(string ienc_text, string ipassword)
        {
            int iv_len = 16;
            byte[] toEncryptArray = Convert.FromBase64String(ienc_text);
            string encryptedString = Encoding.GetEncoding("iso-8859-1").GetString(toEncryptArray);
            string password = ipassword;
            int i = iv_len;
            int n = encryptedString.Length;
            string plain_text = "";
            string iv = phpXOR(ipassword, encryptedString.Substring(0, iv_len));
            while (i < n)
            {
                string block = encryptedString.Substring(i, iv_len);
                string md5 = getMD5(iv);
                byte[] testPack = PackH(md5);
                string testPackstring = Encoding.GetEncoding("iso-8859-1").GetString(testPack);
                string tmp = phpXOR(block, testPackstring);
                plain_text += tmp;
                //string block_iv = block + iv;
                //string tmp_iv = block_iv;
                //if (block_iv.Length > 512)
                //{
                //    tmp_iv = block_iv.Substring(0, 512);
                //}
                //iv = phpXOR(tmp_iv, password);
                //i += 16;
            }
            return plain_text;
        }
        public static byte[] PackH(string hex)
        {
            if ((hex.Length % 2) == 1) hex += '0';
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
        string phpXOR(string text, string key)
        {
            byte[] result = new byte[key.Length];
            for (int c = 0; c < key.Length; c++)
                result[c] = (byte)(((byte)text[c]) ^ ((byte)key[c]));
            return Encoding.Default.GetString(result);
        }
        public static string getMD5(string iValue)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(iValue);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
                cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash = cryptHandler.ComputeHash(textBytes);
                string ret = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("x");
                    else
                        ret += a.ToString("x");
                }
                return ret;
            }
            catch
            {
                throw;
            }
        }
