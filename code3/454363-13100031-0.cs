        public void Upload(byte[] desKey, byte[] desIV)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Destination);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(UserName, Password);
            FileStream fsInput = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
            MemoryStream fsEncrypted = new MemoryStream();
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = desKey;
            DES.IV = desIV;
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            fsInput.Close();
            byte[] fileContents = fsEncrypted.ToArray();
            
            fsEncrypted.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }
