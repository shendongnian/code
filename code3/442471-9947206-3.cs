    private DateTime GetFtpFileDate(string url, ICredentials credential)
    {
        FtpWebRequest rd = (FtpWebRequest)WebRequest.Create(url);
        rd.Method = WebRequestMethods.Ftp.GetDateTimestamp;
        rd.Credentials = credential;
    
        FtpWebResponse response = (FtpWebResponse)rd.GetResponse();
        DateTime lmd = response.LastModified;
        response.Close();
 
        return lmd;
    }
