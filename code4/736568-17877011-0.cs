    private static string Encrypt(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
            {
                // Convert strings into byte arrays.
                // Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
                // encoding.
                var initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                var saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
    
                // Convert our plaintext into a byte array.
                // Let us assume that plaintext contains UTF8-encoded characters.
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
    
                // First, we must create a password, from which the key will be derived.
                // This password will be generated from the specified passphrase and 
                // salt value. The password will be created using the specified hash 
                // algorithm. Password creation can be done in several iterations.
                var password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
    
                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                var keyBytes = password.GetBytes(keySize / 8);
    
                // Create uninitialized Rijndael encryption object.
    
                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC };
    
                // Generate encryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
    
                // Define memory stream which will be used to hold encrypted data.
                var memoryStream = new MemoryStream();
    
                // Define cryptographic stream (always use Write mode for encryption).
                var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
    
                // Start encrypting.
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
    
                // Finish encrypting.
                cryptoStream.FlushFinalBlock();
    
                // Convert our encrypted data from a memory stream into a byte array.
                var cipherTextBytes = memoryStream.ToArray();
    
                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();
    
                // Convert encrypted data into a base64-encoded string.
                var cipherText = Convert.ToBase64String(cipherTextBytes);
    
                // Return encrypted string.
                return cipherText;
            }
    private static string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
            {
                // Convert strings defining encryption key characteristics into byte
                // arrays. Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                // encoding.
                var initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                var saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
    
                // Convert our ciphertext into a byte array.
                var cipherTextBytes = Convert.FromBase64String(cipherText);
    
                // First, we must create a password, from which the key will be 
                // derived. This password will be generated from the specified 
                // passphrase and salt value. The password will be created using
                // the specified hash algorithm. Password creation can be done in
                // several iterations.
                var password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
    
                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                var keyBytes = password.GetBytes(keySize / 8);
    
                // Create uninitialized Rijndael encryption object.
                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC };
    
                // Generate decryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
    
                // Define memory stream which will be used to hold encrypted data.
                var memoryStream = new MemoryStream(cipherTextBytes);
    
                // Define cryptographic stream (always use Read mode for encryption).
                var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
    
                // Since at this point we don't know what the size of decrypted data
                // will be, allocate the buffer long enough to hold ciphertext;
                // plaintext is never longer than ciphertext.
                var plainTextBytes = new byte[cipherTextBytes.Length];
    
                // Start decrypting.
                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
    
                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();
    
                // Convert decrypted data into a string. 
                // Let us assume that the original plaintext string was UTF8-encoded.
                var plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
    
                // Return decrypted string.   
                return plainText;
            }
    public static string EncryptData(string encryptText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
    {
        return Encrypt(encryptText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
    }
    public static string DecryptData(string decryptText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
    {
        return Decrypt(decryptText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
    }
