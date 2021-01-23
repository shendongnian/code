    public DateTime getFileCreatedDateTime(string fileName)
    {
        try
        {
            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
            ftpRequest.Credentials = new NetworkCredential(user, pass);
            
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = true;
            
            ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            
            return ftpResponse.LastModified;
        }
        catch (Exception ex) 
        {
            // Don't like doing this, but I'll leave it here
            // to maintain compatability with the existing code:
            Console.WriteLine(ex.ToString());
        }
        
        return DateTime.MinValue;
    }
