    public static void UploadFileToFtp(string url, string filePath, string username, string password)
    {
        var fileName = Path.GetFileName(filePath);
        var request = (FtpWebRequest)WebRequest.Create(url + fileName);
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential(username, password);
        request.UsePassive = true;
        request.UseBinary = true;
        request.KeepAlive = false;
        using (var fileStream = File.OpenRead(filePath))
        {
            using (var requestStream = request.GetRequestStream())
            {
                fileStream.CopyTo(requestStream);
                requestStream.Close();
            }
        }
        var response = (FtpWebResponse)request.GetResponse();
        Console.WriteLine("Upload done: {0}", response.StatusDescription);
        response.Close();
    }
