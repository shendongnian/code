    public static System.IO.Stream GetFileAsStream(string ftpUrl, string username, string password, bool usePassive, long offset, int requestTimeout)
    {
      System.Net.FtpWebRequest request = (System.Net.FtpWebRequest)System.Net.WebRequest.Create(ftpUrl);
      
      request.KeepAlive = false;
      request.ReadWriteTimeout = requestTimeout;
      request.Timeout = requestTimeout;
      request.ContentOffset = offset;
      request.UsePassive = usePassive;
      request.UseBinary = true;
      request.Credentials = new System.Net.NetworkCredential(username, password);
      request.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
      System.IO.Stream fileResponseStream;
      System.Net.FtpWebResponse fileResponse = (System.Net.FtpWebResponse)request.GetResponse();
      
      fileResponseStream = fileResponse.GetResponseStream();
      return fileResponseStream;
    }
    public static long GetFileLength(string ftpUrl, string username, string password, bool usePassive)
    {
      System.Net.FtpWebRequest request = (System.Net.FtpWebRequest)System.Net.WebRequest.Create(ftpUrl);
      request.KeepAlive = false;
      request.UsePassive = usePassive;
      request.Credentials = new System.Net.NetworkCredential(username, password);
      request.Method = System.Net.WebRequestMethods.Ftp.GetFileSize;
      System.Net.FtpWebResponse lengthResponse = (System.Net.FtpWebResponse)request.GetResponse();
      long length = lengthResponse.ContentLength;
      lengthResponse.Close();
      return length;
    }
