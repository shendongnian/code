       private void button2_Click(object sender, EventArgs e)
        {
            String encrypted = PCL.CentralClass.Encrypt("yo");
            String decreypted = PCL.CentralClass.Decrypt(encrypted);
            //PCL.CentralClass.
        }
        //https://pclcontrib.codeplex.com/documentation?FocusElement=Comment
        //\Source\Portable.Security.Cryptography.ProtectedData\Security\Cryptography\ProtectedData.cs
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        public static String Encrypt(String strEncrypt)
        {
            byte[] userData = GetBytes(strEncrypt);
            byte[] optionalEntropy = null;
            byte[] x = System.Security.Cryptography.ProtectedData.Protect(userData, optionalEntropy);
            return GetString(x);
        }
        public static String Decrypt(String strDecrypt)
        {
            byte[] encryptedData = GetBytes(strDecrypt);
            byte[] optionalEntropy = null;
            byte[] x = System.Security.Cryptography.ProtectedData.Unprotect(encryptedData, optionalEntropy);
            return GetString(x); ;
        }
