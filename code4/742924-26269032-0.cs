        // using System.Diagnostics;
        // using Windows.Storage.Streams;
        // using System.IO;
        // using System.Runtime.InteropServices.WindowsRuntime; // (convert streams from Windows. to System. and vice-versa)
        // using Windows.Security.Credentials;
        // using Windows.Security.Cryptography;
        // using Windows.Security.Cryptography.DataProtection;
        public async void EnDeCryptDataUsingWebcredentials()
        {
            #region Set up environment
            // Specify variables for mock PasswordCredential
            string credentialResource = "MyResourceIdentifier";
            string credentialUserName = "Foo";
            string credentialPassword = "Bar";
            // Get a vault instance.
            PasswordVault passwordVault = new PasswordVault();
            // Inject new credential
            PasswordCredential testCredential = new PasswordCredential(credentialResource, credentialUserName, credentialPassword);
            passwordVault.Add(testCredential);
            
            #endregion Set up environment
            string dataToEncrypt = "The quick brown fox jumped over the lazy dog.";
            Debug.WriteLine(String.Format("UnencryptedData: {0}", dataToEncrypt));
            // Assemble descriptor from PasswordCredential.
            PasswordCredential credential = passwordVault.Retrieve(credentialResource, credentialUserName);
            string dataProtectionDescriptor = String.Format("WEBCREDENTIALS={0},{1}", credential.UserName, credential.Resource);
            Debug.WriteLine("Encryption Descriptor: {0}", dataProtectionDescriptor);
            // Encrypt data.
            DataProtectionProvider encryptionProvider = new DataProtectionProvider(dataProtectionDescriptor);
            IBuffer unencryptedDataBuffer = CryptographicBuffer.ConvertStringToBinary(dataToEncrypt, BinaryStringEncoding.Utf8);
            IBuffer inputDataBuffer = await encryptionProvider.ProtectAsync(unencryptedDataBuffer);
            // View encrypted data as string.
            string encryptedData = String.Empty;
            using (StreamReader reader = new StreamReader(inputDataBuffer.AsStream()))
            {
                encryptedData = reader.ReadToEnd();
            }
            Debug.WriteLine(String.Format("EncryptedData: {0}", encryptedData));
            // Decrypt data (never supply a descriptor for decryption).
            DataProtectionProvider decryptionProvider = new DataProtectionProvider();
            IBuffer outputDataBuffer = await decryptionProvider.UnprotectAsync(inputDataBuffer);
            // View decrypted data as string.
            string decryptedData = String.Empty;
            using (StreamReader reader = new StreamReader(outputDataBuffer.AsStream()))
            {
                decryptedData = reader.ReadToEnd();
            }
            Debug.WriteLine(String.Format("\nDecryptedData: {0}", decryptedData));
        }
