            try
            {
                WebClient request = new WebClient();
                request.Credentials = new NetworkCredential(user, pass);
                byte[] data = request.DownloadData(host);
                MemoryStream file = new MemoryStream(data);
                Upload(data);
            }
            catch (Exception ex)
            {
            }
        ...
        private void Upload(byte[] buffer)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(newname);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(user, pass);
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
                var resp = (FtpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                
            }
        }
