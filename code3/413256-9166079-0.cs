    public List<string> DownloadFileNames()
            {
                    string uri = "ftp://" + ftpServerIP + "/";
                    FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(uri);
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    reqFTP.EnableSsl = true;
                    reqFTP.KeepAlive = false;
                    reqFTP.UseBinary = true;
                    reqFTP.UsePassive = Settings.UsePassive;
                    reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    List<string> files = new List<string>();
                    StreamReader reader = new StreamReader(responseStream);
                    while (!reader.EndOfStream)
                        files.Add(reader.ReadLine());
                    reader.Close();
                    responseStream.Dispose();
                    return files;
            }
