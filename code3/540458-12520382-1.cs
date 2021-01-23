        private void DownloadFile(string userName, string password, string ftpSourceFilePath, string localDestinationFilePath)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[2048];
            FtpWebRequest request = CreateFtpWebRequest(ftpSourceFilePath, userName, password, true);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            Stream reader = request.GetResponse().GetResponseStream();
            FileStream fileStream = new FileStream(localDestinationFilePath, FileMode.Create);
            while (true)
            {
                bytesRead = reader.Read(buffer, 0, buffer.Length);
                
                if (bytesRead == 0)
                    break;
                fileStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();       
        }
