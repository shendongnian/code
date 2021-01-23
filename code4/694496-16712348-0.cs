    class Program
    {
        public static void Main(string[] args)
        {
            //Encrypt and export public and private keys
            var rsa1 = new RSACryptoServiceProvider();
            string publicPrivateXml = rsa1.ToXmlString(true);   // <<<<<<< HERE
            byte[] toEncryptData = Encoding.ASCII.GetBytes("hello world");
            byte[] encryptedRSA = rsa1.Encrypt(toEncryptData, false);
            string EncryptedResult = Encoding.Default.GetString(encryptedRSA);
    
            //Decrypt using exported keys
            var rsa2 = new RSACryptoServiceProvider();
            rsa2.FromXmlString(publicPrivateXml);    
            byte[] decryptedRSA = rsa2.Decrypt(encryptedRSA, false);
            string originalResult = Encoding.Default.GetString(decryptedRSA);
    
        }
    }
