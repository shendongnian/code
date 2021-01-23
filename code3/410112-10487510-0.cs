        /// <summary>Computes a Hash-based Message Authentication Code (HMAC) using the AES hash function.</summary>
        public class AesHmac : HMAC
        {
            /// <summary>Initializes a new instance of the AesHmac class with the specified key data.</summary>
            /// <param name="key">The secret key for AesHmac encryption.</param>
            public AesHmac(byte[] key)
            {
                HashName = "System.Security.Cryptography.AesCryptoServiceProvider";
                HashSizeValue = 128;
                BlockSizeValue = 128;
                Initialize();
                Key = (byte[])key.Clone();
            }
        }
        /// <summary>Computes a Hash-based Message Authentication Code (HMAC) using the SHA256 hash function.</summary>
        public class ShaHmac : HMAC
        {
            /// <summary>Initializes a new instance of the ShaHmac class with the specified key data.</summary>
            /// <param name="key">The secret key for ShaHmac encryption.</param>
            public ShaHmac(byte[] key)
            {
                HashName = "System.Security.Cryptography.SHA256CryptoServiceProvider";
                HashSizeValue = 256;
                BlockSizeValue = 128;
                Initialize();
                Key = (byte[])key.Clone();
            }
        }
