        private static FtpWebRequest CreateFtpWebRequest(string ftpUrl, string userName, string password, bool useSsl, bool allowInvalidCertificate, bool useActiveFtp)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
            request.Credentials = new NetworkCredential(userName, password);
            if (useSsl)
            {
                request.EnableSsl = true;
                if (allowInvalidCertificate)
                {
                    ServicePointManager.ServerCertificateValidationCallback = ServicePointManager_ServerCertificateValidationCallback;
                }
                else
                {
                    ServicePointManager.ServerCertificateValidationCallback = null;
                }
            }
            request.UsePassive = !useActiveFtp;
            return request;
        }
        private static FtpStatusCode UploadFileToServer(string ftpUrl, string userName, string password, bool useSsl, bool allowInvalidCertificate, bool useActiveFtp, string filePath)
        {
            FtpWebRequest request = CreateFtpWebRequest(ftpUrl, userName, password, useSsl, allowInvalidCertificate, useActiveFtp);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            long bytesReceived = 0;
            long bytesSent = 0;
            FtpStatusCode statusCode = FtpStatusCode.Undefined;
            using (Stream requestStream = request.GetRequestStream())
            using (FileStream uploadFileStream = File.OpenRead(filePath))
            {
                // Note that this method call requires .NET 4.0 or higher. If using an earlier version it will need to be replaced.
                uploadFileStream.CopyTo(requestStream);
                bytesSent = uploadFileStream.Position;
            }
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                bytesReceived = response.ContentLength;
                statusCode = response.StatusCode;
            }
            return statusCode;
        }
