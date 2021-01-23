    public static List<string> ListDirectory(string dirPath, string ftpUser, string ftpPassword)
    {
       List<string> res = new List<string>();
       FtpWebRequest request = (FtpWebRequest)WebRequest.Create(dirPath);
       request.Method = WebRequestMethods.Ftp.ListDirectory;
       request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
       request.KeepAlive = false;
       FtpWebResponse response = (FtpWebResponse)request.GetResponse();
       Stream responseStream = response.GetResponseStream();
       StreamReader reader = new StreamReader(responseStream);
       while (!reader.EndOfStream)
       {
          res.Add(reader.ReadLine());
       }
       reader.Close();
       response.Close();
       return res;
    } 
