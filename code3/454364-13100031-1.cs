        public void Upload(byte[] key, byte[] iv)
        {
            byte[] fileContents;
            using (FileStream inputeFile = new FileStream(this.SourceFile, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream encryptedStream = new MemoryStream())
                {
                    using (CryptoStream cryptostream = new CryptoStream(encryptedStream, new DESCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    {
                        byte[] bytearrayinput = new byte[inputeFile.Length];
                        inputeFile.Read(bytearrayinput, 0, bytearrayinput.Length);
                        cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                        fileContents = encryptedStream.ToArray();
                    }
                }
            }
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(this.Destination);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(this.UserName, this.Password);
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }
