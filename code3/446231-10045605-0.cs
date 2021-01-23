    class FtpRequests {
      private const int BUF_SIZE = 10240;
      private const string PASSWORD = "password";
      private const string USERNAME = "username";
      private const string SERVER = "yourserver.com";
      private string path;
      public FtpRequests() {
        Cancel = false;
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      }
      public bool Cancel { get; set; }
      public bool Complete { get; set; }
      public Thread Thread1 { get; set; }
      public int Timeout { get; set; }
      public int ReadWriteTimeout { get; set; }
      public void StartFtpDownload(string download, string file) {
        string objString = string.Format("{0};{1}", download, file);
        Thread1 = new Thread(startFtpThread);
        Thread1.Name = string.Format("{0} download", file);
        Thread1.IsBackground = true;
        Thread1.Start(objString);
      }
      private void startFtpThread(object obj) {
        Complete = false;
        string objString = obj.ToString();
        string[] split = objString.Split(';');
        string download = split[0];
        string file = split[1];
        do {
          try {
            string uri = String.Format("ftp://{0}/{1}/{2}", SERVER, download, file);
            Uri serverUri = new Uri(uri);
            if (serverUri.Scheme != Uri.UriSchemeFtp) {
              Cancel = true;
              return;
            }
            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(USERNAME, PASSWORD);
            reqFTP.KeepAlive = true;
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
            reqFTP.EnableSsl = false;
            reqFTP.Proxy = null;
            reqFTP.UsePassive = true;
            reqFTP.Timeout = Timeout;
            reqFTP.ReadWriteTimeout = ReadWriteTimeout;
            using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse()) {
              using (Stream responseStream = response.GetResponseStream()) {
                using (FileStream writeStream = new FileStream(path + file, FileMode.Create)) {
                  Byte[] buffer = new Byte[BUF_SIZE];
                  int bytesRead = responseStream.Read(buffer, 0, BUF_SIZE);
                  while (0 < bytesRead) {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, BUF_SIZE);
                  }
                }
                responseStream.Close();
              }
              response.Close();
              Complete = true;
            }
          } catch (WebException wEx) {
            LogDatabase.WriteLog("Download File", wEx.ToString(), "Download File");
          }
        } while (!Cancel && !Complete);
      }
    }
