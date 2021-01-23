        public static byte[] HashIt(string text)
        {
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text);
            System.Security.Cryptography.PasswordDeriveBytes pdb = new System.Security.Cryptography.PasswordDeriveBytes(textBytes, new byte[0]);
            byte[] hashBytes = pdb.CryptDeriveKey("TripleDES", "MD5", 0, new byte[8]);
            byte[] head = new byte[] { 0x08,0x02, 0x00, 0x00, 0x03, 0x66, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00 };
            byte[] hashBytesWithHead = new byte[hashBytes.Length + head.Length];
            head.CopyTo(hashBytesWithHead,0);
            hashBytes.CopyTo(hashBytesWithHead,head.Length);
            return (hashBytesWithHead);
        }
