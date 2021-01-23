    try
    {
       FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(model.configData.FTPInputFolder));
       request.Credentials = new NetworkCredential("ftp_free", "ftp_free");
       request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;
       request.KeepAlive = false;
       request.UsePassive = false;
       using(FtpWebResponse response = (FtpWebResponse)request.GetResponse())
       {}
    }
    catch (WebException e)
    {
      ModelState.AddModelError("configData.FTPInputFolder", "Directory does not exist " + e.Message);
    }
    ...
