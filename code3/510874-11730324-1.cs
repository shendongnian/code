        public static byte[] encrypt(string xmlKey, byte[] bytes)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlKey);
                return rsa.Encrypt(bytes, false);
            }
        }
