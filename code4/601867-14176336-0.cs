    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using Xunit;
    
    public interface IStringEncryptor {
        string EncryptString(string plainText);
        string DecryptString(string encryptedText);
    }
    
    public class AESStringEncryptor : IStringEncryptor {
        private readonly Encoding _encoding;
        private readonly byte[] _key;
        private readonly Rfc2898DeriveBytes _passwordDeriveBytes;
        private readonly byte[] _salt;
    
        /// <summary>
        /// Overload of full constructor that uses UTF8Encoding as the default encoding.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="salt"></param>
        public AESStringEncryptor(string key, string salt)
            : this(key, salt, new UTF8Encoding()) {
        }
    
        public AESStringEncryptor(string key, string salt, Encoding encoding) {
            _encoding = encoding;
            _passwordDeriveBytes = new Rfc2898DeriveBytes(key, _encoding.GetBytes(salt));
            _key = _passwordDeriveBytes.GetBytes(32);
            _salt = _passwordDeriveBytes.GetBytes(16);
        }
    
        /// <summary>
        /// Encrypts any string to a Base64 string
        /// </summary>
        /// <param name="plainText"></param>
        /// <exception cref="ArgumentNullException">String to encrypt cannot be null or empty.</exception>
        /// <returns>A Base64 string representing the encrypted version of the plainText</returns>
        public string EncryptString(string plainText) {
            if (string.IsNullOrEmpty(plainText)) {
                throw new ArgumentNullException("plainText");
            }
    
            using (var alg = new RijndaelManaged { BlockSize = 128, FeedbackSize = 128, Key = _key, IV = _salt })
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write)) {
                var plainTextBytes = _encoding.GetBytes(plainText);
    
                cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                cs.FlushFinalBlock();
    
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    
        /// <summary>
        /// Decrypts a Base64 string to the original plainText in the given Encoding
        /// </summary>
        /// <param name="encryptedText">A Base64 string representing the encrypted version of the plainText</param>
        /// <exception cref="ArgumentNullException">String to decrypt cannot be null or empty.</exception>
        /// <exception cref="CryptographicException">Thrown if password, salt, or encoding is different from original encryption.</exception>
        /// <returns>A string encoded</returns>
        public string DecryptString(string encryptedText) {
            if (string.IsNullOrEmpty(encryptedText)) {
                throw new ArgumentNullException("encryptedText");
            }
    
            using (var alg = new RijndaelManaged { BlockSize = 128, FeedbackSize = 128, Key = _key, IV = _salt })
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write)) {
                var encryptedTextBytes = Convert.FromBase64String(encryptedText);
    
                cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
                cs.FlushFinalBlock();
    
                return _encoding.GetString(ms.ToArray());
            }
        }
    }
    
    public class AESStringEncryptorTest {
        private const string Password = "TestPassword";
        private const string Salt = "TestSalt";
    
        private const string Plaintext = "This is a test";
    
        [Fact]
        public void EncryptionAndDecryptionWorkCorrectly() {
            var aesStringEncryptor = new AESStringEncryptor(Password, Salt);
    
            string encryptedText = aesStringEncryptor.EncryptString(Plaintext);
    
            Assert.NotEqual(Plaintext, encryptedText);
    
            var aesStringDecryptor = new AESStringEncryptor(Password, Salt);
    
            string decryptedText = aesStringDecryptor.DecryptString(encryptedText);
    
            Assert.Equal(Plaintext, decryptedText);
        }
    
        [Fact]
        public void EncodingsWorkWhenSame()
        {
            var aesStringEncryptor = new AESStringEncryptor(Password, Salt, Encoding.ASCII);
    
            string encryptedText = aesStringEncryptor.EncryptString(Plaintext);
    
            Assert.NotEqual(Plaintext, encryptedText);
    
            var aesStringDecryptor = new AESStringEncryptor(Password, Salt, Encoding.ASCII);
    
            string decryptedText = aesStringDecryptor.DecryptString(encryptedText);
    
            Assert.Equal(Plaintext, decryptedText);
        }
    
        [Fact]
        public void EncodingsFailWhenDifferent() {
            var aesStringEncryptor = new AESStringEncryptor(Password, Salt, Encoding.UTF32);
    
            string encryptedText = aesStringEncryptor.EncryptString(Plaintext);
    
            Assert.NotEqual(Plaintext, encryptedText);
    
            var aesStringDecryptor = new AESStringEncryptor(Password, Salt, Encoding.UTF8);
    
            Assert.Throws<CryptographicException>(() => aesStringDecryptor.DecryptString(encryptedText));
        }
    
        [Fact]
        public void EncryptionAndDecryptionWithWrongPasswordFails()
        {
            var aes = new AESStringEncryptor(Password, Salt);
    
            string encryptedText = aes.EncryptString(Plaintext);
    
            Assert.NotEqual(Plaintext, encryptedText);
    
            var badAes = new AESStringEncryptor(Password.ToLowerInvariant(), Salt);
    
            Assert.Throws<CryptographicException>(() => badAes.DecryptString(encryptedText));
        }
    
        [Fact]
        public void EncryptionAndDecryptionWithWrongSaltFails()
        {
            var aes = new AESStringEncryptor(Password, Salt);
    
            string encryptedText = aes.EncryptString(Plaintext);
    
            Assert.NotEqual(Plaintext, encryptedText);
    
            var badAes = new AESStringEncryptor(Password, Salt.ToLowerInvariant());
    
            Assert.Throws<CryptographicException>(() => badAes.DecryptString(encryptedText));
        }
    }
    
