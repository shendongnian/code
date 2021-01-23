    protected string CheckDir(string fullpath, string c_ip, string c_acc, string c_pwd)
            {
                string[] path = fullpath.Split(slash[1]);
    
                bool result = false;
    
                try
                {
                    if (WebRequestMethods.Ftp.ListDirectoryDetails.Contains(c_ip + path[2]))
                    {
                        result = true;
                    }
                    else
                    {
                        FtpWebRequest request = (FtpWebRequest)(WebRequest.Create(c_ip + path[2]));
                        request.Credentials = new NetworkCredential(c_acc, c_pwd);
                        request.Method = WebRequestMethods.Ftp.MakeDirectory;
                        request.KeepAlive = false;
                        try
                        {
                            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                            response.Close();
                        }
                        catch (Exception)
                        {
                            request.Abort();
                            result = false;
                        }
                        request.Abort();
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
    
                if (result == true)
                    return path[2];
                else
                    return null;
            }
