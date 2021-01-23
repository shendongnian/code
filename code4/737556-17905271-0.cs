        public void ProcessRequest(HttpContext context)
        {
            if (!this.HasAccess())
            {
                context.Response.End();
            }
            string requestFileName = context.Request.QueryString["FileName"];
            DecryptFile(requestFileName, context);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private bool HasAccess()
        {
            // Check if user is logged in and has permissions
            // to do the decryption
            return true;
        }
        private void DecryptFile(string inputFile, HttpContext context)
        {
            inputFile = PathTraversalCheck(inputFile);
            string password = @"myKey123"; // Your Key Here
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);
            using (FileStream encryptedFile = new FileStream(inputFile, FileMode.Open))
            {
                RijndaelManaged rijndael = new RijndaelManaged();
                using (MemoryStream output = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(encryptedFile, rijndael.CreateDecryptor(key, key), CryptoStreamMode.Read))
                    {
                        var buffer = new byte[1024];
                        var read = cryptoStream.Read(buffer, 0, buffer.Length);
                        while (read > 0)
                        {
                            output.Write(buffer, 0, read);
                            read = cryptoStream.Read(buffer, 0, buffer.Length);
                        }
                        cryptoStream.Flush();
                        context.Response.ContentType = "image/jpeg";
                        context.Response.BinaryWrite(output.ToArray());
                    }
                }
            }
        }
        private string PathTraversalCheck(string inputFile)
        {
            inputFile = inputFile.Replace('/', '\\').Replace("..\\", string.Empty);
            return inputFile;
        }
    }
