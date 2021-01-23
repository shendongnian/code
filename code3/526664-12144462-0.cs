    private void EncryptFile(string szFilePath, string szInfoFile, string szKey, string szEncryptedFile = "")
        {
            // Blowfish
            Blowfish alg = new Blowfish(Encoding.Unicode.GetBytes(szKey));
            // Open file
            using (System.IO.FileStream originalStream = System.IO.File.OpenRead(szFilePath))
            {
                // Store original file length
                long originalLength = originalStream.Length;
                System.IO.File.WriteAllText(szInfoFile, originalLength.ToString());
                Byte[] buffer = new byte[originalStream.Length + (originalStream.Length % 8)];
                originalStream.Read(buffer, 0, buffer.Length);
            }
            // Encrypt
            alg.Encipher(buffer, buffer.Length);
            string szEncFile;
            szEncFile = string.IsNullOrEmpty(szEncryptedFile) ? szFilePath : szEncryptedFile;
            using (System.IO.FileStream stream = new System.IO.FileStream(szEncFile, System.IO.FileMode.Create))
            {
                stream.Write(buffer, 0, buffer.Length);
            }
        }
