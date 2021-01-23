    public string UploadFile(string FileFromPath, string ToFTPURL, string SubDirectoryName, string FTPLoginID, string
    FTPPassword)
        {
            try
            {
                string FtpUrl = string.Empty;
                FtpUrl = ToFTPURL + "/" + SubDirectoryName;    //Complete FTP Url path
                string[] files = Directory.GetFiles(FileFromPath, "*.*");    //To get each file name from FileFromPath
               
                foreach (string file in files)
                {
                    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FtpUrl + "/" + Path.GetFileName(file));
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(FTPLoginID, FTPPassword);
                    request.UsePassive = true;
                    request.UseBinary = true;
                    request.KeepAlive = false;
                    FileStream stream = File.OpenRead(FileFromPath + "\\" + Path.GetFileName(file));
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    stream.Close();
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Close();
                }
                return "Success";
            }
            catch(Exception ex)
            {
                return "ex";
            }
        }
