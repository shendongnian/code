    public class Crypto
    {
            #region enums, constants & fields
            //types of symmetric encyption
            public enum CryptoTypes
            {
                encTypeDES = 0,
                encTypeRC2,
                encTypeRijndael,
                encTypeTripleDES
            }
        private const string CRYPT_DEFAULT_PASSWORD = "yourDefaultPassword"; //"CB06cfE507a1";
        private const CryptoTypes CRYPT_DEFAULT_METHOD = CryptoTypes.encTypeRijndael;
 
        private byte[] mKey = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
        private byte[] mIV = {65, 110, 68, 26, 69, 178, 200, 219};
        private byte[] SaltByteArray  = {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76};
        private CryptoTypes mCryptoType = CRYPT_DEFAULT_METHOD;
        private string mPassword = CRYPT_DEFAULT_PASSWORD;
        #endregion
 
        #region Constructors
 
        public Crypto()
        {
            calculateNewKeyAndIV();
        }
 
        public Crypto(CryptoTypes CryptoType)
        {
            this.CryptoType = CryptoType;
        }
        #endregion
 
        #region Props
 
        /// <summary>
        ///     type of encryption / decryption used
        /// </summary>
        public CryptoTypes CryptoType
        {
            get
            {
                return mCryptoType;
            }
            set
            {
                if (mCryptoType != value)
                {
                    mCryptoType = value;
                    calculateNewKeyAndIV();
                }
            }
        }
 
        /// <summary>
        ///     Passsword Key Property.
        ///     The password key used when encrypting / decrypting
        /// </summary>
        public string Password
        {
            get
            {
                return mPassword;
            }
            set
            {
                if (mPassword != value)
                {
                    mPassword = value;
                    calculateNewKeyAndIV();
                }
            }
        }
        #endregion
 
        #region Encryption
 
        /// <summary>
        ///     Encrypt a string
        /// </summary>
        /// <param storeName="inputText">text to encrypt</param>
        /// <returns>an encrypted string</returns>
        public string Encrypt(string inputText)
        {
            //declare a new encoder
            UTF8Encoding UTF8Encoder = new UTF8Encoding();
            //get byte representation of string
            byte[] inputBytes = UTF8Encoder.GetBytes(inputText);
 
            //convert back to a string
            return Convert.ToBase64String(EncryptDecrypt(inputBytes,true));
        }
 
        /// <summary>
        ///     Encrypt string with user defined password
        /// </summary>
        /// <param storeName="inputText">text to encrypt</param>
        /// <param storeName="password">password to use when encrypting</param>
        /// <returns>an encrypted string</returns>
        public string Encrypt(string inputText, string password)
        {
            this.Password = password;
            return this.Encrypt(inputText);
        }
 
        /// <summary>
        ///     Encrypt string acc. to cryptoType and with user defined password
        /// </summary>
        /// <param storeName="inputText">text to encrypt</param>
        /// <param storeName="password">password to use when encrypting</param>
        /// <param storeName="cryptoType">type of encryption</param>
        /// <returns>an encrypted string</returns>
        public string Encrypt(string inputText, string password, CryptoTypes cryptoType)
        {
            mCryptoType = cryptoType;
            return this.Encrypt(inputText,password);
        }
 
        /// <summary>
        ///     Encrypt string acc. to cryptoType
        /// </summary>
        /// <param storeName="inputText">text to encrypt</param>
        /// <param storeName="cryptoType">type of encryption</param>
        /// <returns>an encrypted string</returns>
        public string Encrypt(string inputText, CryptoTypes cryptoType)
        {
            this.CryptoType = cryptoType;
            return this.Encrypt(inputText);
        }
 
        #endregion
 
        #region Decryption
 
        /// <summary>
        ///     decrypts a string
        /// </summary>
        /// <param storeName="inputText">string to decrypt</param>
        /// <returns>a decrypted string</returns>
        public string Decrypt(string inputText)
        {
            //declare a new encoder
            UTF8Encoding UTF8Encoder = new UTF8Encoding();
            //get byte representation of string
            byte[] inputBytes = Convert.FromBase64String(inputText);
 
            //convert back to a string
            return UTF8Encoder.GetString(EncryptDecrypt(inputBytes,false));
        }
 
        /// <summary>
        ///     decrypts a string using a user defined password key
        /// </summary>
        /// <param storeName="inputText">string to decrypt</param>
        /// <param storeName="password">password to use when decrypting</param>
        /// <returns>a decrypted string</returns>
        public string Decrypt(string inputText, string password)
        {
            this.Password = password;
            return Decrypt(inputText);
        }
 
        /// <summary>
        ///     decrypts a string acc. to decryption type and user defined password key
        /// </summary>
        /// <param storeName="inputText">string to decrypt</param>
        /// <param storeName="password">password key used to decrypt</param>
        /// <param storeName="cryptoType">type of decryption</param>
        /// <returns>a decrypted string</returns>
        public string Decrypt(string inputText, string password, CryptoTypes cryptoType)
        {
            mCryptoType = cryptoType;
            return Decrypt(inputText,password);
        }
 
        /// <summary>
        ///     decrypts a string acc. to the decryption type
        /// </summary>
        /// <param storeName="inputText">string to decrypt</param>
        /// <param storeName="cryptoType">type of decryption</param>
        /// <returns>a decrypted string</returns>
        public string Decrypt(string inputText, CryptoTypes cryptoType)
        {
            this.CryptoType = cryptoType;
            return Decrypt(inputText);
        }
        #endregion
 
        #region Symmetric Engine
 
        /// <summary>
        ///     performs the actual enc/dec.
        /// </summary>
        /// <param storeName="inputBytes">input byte array</param>
        /// <param storeName="Encrpyt">wheather or not to perform enc/dec</param>
        /// <returns>byte array output</returns>
        private byte[] EncryptDecrypt(byte[] inputBytes, bool Encrpyt)
        {
            //get the correct transform
            ICryptoTransform transform = getCryptoTransform(Encrpyt);
 
            //memory stream for output
            MemoryStream memStream = new MemoryStream();
 
            try
            {
                //setup the cryption - output written to memstream
                CryptoStream cryptStream = new CryptoStream(memStream,transform,CryptoStreamMode.Write);
 
                //write data to cryption engine
                cryptStream.Write(inputBytes,0,inputBytes.Length);
 
                //we are finished
                cryptStream.FlushFinalBlock();
 
                //get result
                byte[] output = memStream.ToArray();
 
                //finished with engine, so close the stream
                cryptStream.Close();
 
                return output;
            }
            catch (Exception e)
            {
                //throw an error
                throw new Exception("Error in symmetric engine. Error : " + e.Message,e);
            }
        }
 
        /// <summary>
        ///     returns the symmetric engine and creates the encyptor/decryptor
        /// </summary>
        /// <param storeName="encrypt">whether to return a encrpytor or decryptor</param>
        /// <returns>ICryptoTransform</returns>
        private ICryptoTransform getCryptoTransform(bool encrypt)
        {
            SymmetricAlgorithm SA = selectAlgorithm();
            SA.Key = mKey;
            SA.IV = mIV;
            if (encrypt)
            {
                return SA.CreateEncryptor();
            }else
            {
                return SA.CreateDecryptor();
            }
        }
        /// <summary>
        ///     returns the specific symmetric algorithm acc. to the cryptotype
        /// </summary>
        /// <returns>SymmetricAlgorithm</returns>
        private SymmetricAlgorithm selectAlgorithm()
        {
            SymmetricAlgorithm SA;
            switch (mCryptoType)
            {
                case CryptoTypes.encTypeDES:
                    SA = DES.Create();
                    break;
                case CryptoTypes.encTypeRC2:
                    SA = RC2.Create();
                    break;
                case CryptoTypes.encTypeRijndael:
                    SA = Rijndael.Create();
                    break;
                case CryptoTypes.encTypeTripleDES:
                    SA = TripleDES.Create();
                    break;
                default:
                    SA = TripleDES.Create();
                    break;
            }
            return SA;
        }
 
        /// <summary>
        ///     calculates the key and IV acc. to the symmetric method from the password
        ///     key and IV size dependant on symmetric method
        /// </summary>
        private void calculateNewKeyAndIV()
        {
            //use salt so that key cannot be found with dictionary attack
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(mPassword,SaltByteArray);
            SymmetricAlgorithm algo = selectAlgorithm();
            mKey = pdb.GetBytes(algo.KeySize / 8);
            mIV = pdb.GetBytes(algo.BlockSize / 8);
        }
 
        #endregion
    }
 
    /// <summary>
    /// Hashing class. Only static members so no need to create an instance
    /// </summary>
    public class Hashing
    {
        #region enum, constants and fields
        //types of hashing available
        public enum HashingTypes
        {
            SHA, SHA256, SHA384, SHA512, MD5
        }
        #endregion
 
        #region static members
        public static string Hash(String inputText)
        {
            return ComputeHash(inputText,HashingTypes.MD5);
        }
 
        public static string Hash(String inputText, HashingTypes hashingType)
        {
            return ComputeHash(inputText,hashingType);
        }
 
        /// <summary>
        ///     returns true if the input text is equal to hashed text
        /// </summary>
        /// <param storeName="inputText">unhashed text to test</param>
        /// <param storeName="hashText">already hashed text</param>
        /// <returns>boolean true or false</returns>
        public static bool isHashEqual(string inputText, string hashText)
        {
            return (Hash(inputText) == hashText);
        }
 
        public static bool isHashEqual(string inputText, string hashText, HashingTypes hashingType)
        {
            return (Hash(inputText,hashingType) == hashText);
        }
        #endregion
 
        #region Hashing Engine
 
        /// <summary>
        ///     computes the hash code and converts it to string
        /// </summary>
        /// <param storeName="inputText">input text to be hashed</param>
        /// <param storeName="hashingType">type of hashing to use</param>
        /// <returns>hashed string</returns>
        private static string ComputeHash(string inputText, HashingTypes hashingType)
        {
            HashAlgorithm HA = getHashAlgorithm(hashingType);
 
            //declare a new encoder
            UTF8Encoding UTF8Encoder = new UTF8Encoding();
            //get byte representation of input text
            byte[] inputBytes = UTF8Encoder.GetBytes(inputText);
 
            //hash the input byte array
            byte[] output = HA.ComputeHash(inputBytes);
 
            //convert output byte array to a string
            return Convert.ToBase64String(output);
        }
 
        /// <summary>
        ///     returns the specific hashing alorithm
        /// </summary>
        /// <param storeName="hashingType">type of hashing to use</param>
        /// <returns>HashAlgorithm</returns>
        private static HashAlgorithm getHashAlgorithm(HashingTypes hashingType)
        {
            switch (hashingType)
            {
                case HashingTypes.MD5 :
                    return new MD5CryptoServiceProvider();
                case HashingTypes.SHA :
                    return new SHA1CryptoServiceProvider();
                case HashingTypes.SHA256 :
                    return new SHA256Managed();
                case HashingTypes.SHA384 :
                    return new SHA384Managed();
                case HashingTypes.SHA512 :
                    return new SHA512Managed();
                default :
                    return new MD5CryptoServiceProvider();
            }
        }
        #endregion
 
    }
