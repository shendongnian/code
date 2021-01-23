    public class SecureQuerystring
    {
        public SecureQuerystring()
        {
            m_passPhrase = "#oqT6%hKg";
            m_saltValue = "7651273512";
            m_initVector = "@1B2c3D4e5F6g7H8";
            m_hashAlgorithm = "SHA1";
            m_passwordIterations = 5;
            m_keySize = 128;
        }
        private string m_plaintext;
        private string m_ciphertext;
        private byte[] m_plaintextbytes;
        private byte[] m_ciphertextbytes;
        private string m_passPhrase;
        private string m_saltValue;
        private string m_hashAlgorithm;
        private Int32 m_passwordIterations;
        private string m_initVector;
        private Int32 m_keySize;
        public string plaintext
        {
            get { return m_plaintext; }
            set { m_plaintext = value; }
        }
        public string ciphertext
        {
            get { return m_ciphertext; }
            set { m_ciphertext = value; }
        }
        public byte[] plaintextbytes
        {
            get { return m_plaintextbytes; }
            set { m_plaintextbytes = value; }
        }
        public byte[] ciphertextbytes
        {
            get { return m_ciphertextbytes; }
            set { m_ciphertextbytes = value; }
        }
        public string passPhrase
        {
            get { return m_passPhrase; }
            set { m_passPhrase = value; }
        }
        public string saltValue
        {
            get { return m_saltValue; }
            set { m_saltValue = value; }
        }
        public string hashAlgorithm
        {
            get { return m_hashAlgorithm; }
            set { m_hashAlgorithm = value; }
        }
        public Int32 passwordIterations
        {
            get { return m_passwordIterations; }
            set { m_passwordIterations = value; }
        }
        public string initVector
        {
            get { return m_initVector; }
            set { m_initVector = value; }
        }
        public Int32 keySize
        {
            get { return m_keySize; }
            set { m_keySize = value; }
        }
        public string ASCIIEncrypt(string plaintext2)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(m_initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(m_saltValue);
                byte[] plainTextBytes = Encoding.ASCII.GetBytes(plaintext2);
                PasswordDeriveBytes password = new PasswordDeriveBytes(m_passPhrase, saltValueBytes, m_hashAlgorithm, m_passwordIterations);
                byte[] keyBytes = password.GetBytes(m_keySize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                m_ciphertext = Convert.ToBase64String(cipherTextBytes);
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string ASCIIDecrypt(string ciphertext2)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(m_initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(m_saltValue);
                byte[] cipherTextBytes = Convert.FromBase64String(ciphertext2);
                PasswordDeriveBytes password = new PasswordDeriveBytes(m_passPhrase, saltValueBytes, m_hashAlgorithm, m_passwordIterations);
                byte[] keyBytes = password.GetBytes(keySize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                m_plaintext = Encoding.ASCII.GetString(plainTextBytes);
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
