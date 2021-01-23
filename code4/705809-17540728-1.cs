    public void DownloadFile(string HostURL, string UserName, string Password, string SourceDirectory, string FileName, string LocalDirectory)
            {
                if (!File.Exists(LocalDirectory + FileName))
                {
                    try
                    {
                        FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(HostURL + "/" + SourceDirectory + "/" + FileName);
                        requestFileDownload.Credentials = new NetworkCredential(UserName, Password);
                        requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                        FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
                        Stream responseStream = responseFileDownload.GetResponseStream();
                        FileStream writeStream = new FileStream(LocalDirectory + FileName, FileMode.Create);
                        int Length = 2048;
                        Byte[] buffer = new Byte[Length];
                        int bytesRead = responseStream.Read(buffer, 0, Length);
                        while (bytesRead > 0)
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                            bytesRead = responseStream.Read(buffer, 0, Length);
                        }
                        responseStream.Close();
                        writeStream.Close();
                        requestFileDownload = null;
                        responseFileDownload = null;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
