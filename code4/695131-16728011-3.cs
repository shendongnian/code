    public string[] GetFileList(string path)
            {
                var ftpPath = host + "/" + path;
                var ftpUser = user;
                var ftpPass = pass;
                var result = new StringBuilder();
                try
                {
                    var strLink = ftpPath;
                    var reqFtp = (FtpWebRequest)WebRequest.Create(new Uri(strLink));
                    reqFtp.UseBinary = true;
                    reqFtp.Credentials = new NetworkCredential(ftpUser, ftpPass);
                    reqFtp.Method = WebRequestMethods.Ftp.ListDirectory;
                    reqFtp.Proxy = null;
                    reqFtp.KeepAlive = false;
                    reqFtp.UsePassive = true;
                    using (var response = reqFtp.GetResponse())
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            var line = reader.ReadLine();
                            while (line != null)
                            {
                                result.Append(line);
                                result.Append("\n");
                                line = reader.ReadLine();
                            }
                            result.Remove(result.ToString().LastIndexOf('\n'), 1);
                        }
                    }
                    return result.ToString().Split('\n');
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FTP ERROR: ", ex.Message);
                    return null;
                }
    
                finally
                {
                    ftpRequest = null;
                }
            }
