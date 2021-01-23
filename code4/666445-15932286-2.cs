    var request = (FtpWebRequest)WebRequest.Create("ftp://ftp.myworld.com/file.txt");
    request.Credentials = new NetworkCredential("username", "password");
    request.Method = WebRequestMethods.Ftp.GetFileSize;
    
    try
    {
      FtpWebResponse response = (FtpWebResponse)request.GetResponse();
      
      // To delete file
      FtpWebRequest delRequest = (FtpWebRequest)WebRequest.Create(serverUri);
      delRequest.Credentials = new NetworkCredential("username", "password");
      delRequest.Method = WebRequestMethods.Ftp.DeleteFile;
      FtpWebResponse response = (FtpWebResponse) delRequest.GetResponse();
    }
    catch(Exception e)
    {
       var response = (FtpWebResponse)ex.Response;
       if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
       {
           //not exist
       }
    }
