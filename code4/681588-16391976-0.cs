    public void Upload(Stream stream, string fileName)
    {
        if (stream == null)
        {
            throw new ArgumentNullException("stream");
        }
        try
        {
            FtpWebRequest ftpRequest = CreateFtpRequest(fileName);
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            using (Stream requestSream = ftpRequest.GetRequestStream())
            {
                Pump(stream, requestSream);
            }
            var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
        }
        catch (Exception e)
        {
            throw new FtpException(
                string.Format("Failed to upload object. fileName: {0}, stream: {1}", fileName, stream), e);
        }
    }
    private FtpWebRequest CreateFtpRequest(string fileName)
    {
        if (fileName == null)
        {
            throw new ArgumentNullException("fileName");
        }
        string serverUri = string.Format("{0}{1}", ftpRoot, fileName);
        var ftpRequest = (FtpWebRequest)WebRequest.Create(serverUri);
        ftpRequest.Credentials = new NetworkCredential(configuration.UserName, configuration.Password);
        ftpRequest.UsePassive = true;
        ftpRequest.UseBinary = true;
        ftpRequest.KeepAlive = false;
        return ftpRequest;
    }
    private static void Pump(Stream input, Stream output)
    {
        var buffer = new byte[2048];
        while (true)
        {
            int bytesRead = input.Read(buffer, 0, buffer.Length);
            if (bytesRead == 0)
            {
                break;
            }
            output.Write(buffer, 0, bytesRead);
        }
    }
