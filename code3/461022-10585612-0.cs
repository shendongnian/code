    Uri url = new Uri("ftp://ftp.demo.com/Image1.jpg");
    if (url.Scheme == Uri.UriSchemeFtp)
    {
        FtpWebRequest objRequest = (FtpWebRequest)FtpWebRequest.Create(url);
        //Set credentials if required else comment this Credential code
        NetworkCredential objCredential = new NetworkCredential("FTPUserName", "FTPPassword");
        objRequest.Credentials = objCredential;
        objRequest.Method = WebRequestMethods.Ftp.DownloadFile;
        FtpWebResponse objResponse = (FtpWebResponse)objRequest.GetResponse();
        StreamReader objReader = new StreamReader(objResponse.GetResponseStream());
        byte[] buffer = new byte[16 * 1024];
        int len = 0;
        FileStream objFS = new FileStream(Server.MapPath("Image1.jpg"), FileMode.Create, FileAccess.Write, FileShare.Read);
        while ((len = objReader.BaseStream.Read(buffer, 0, buffer.Length)) != 0)
        {
            objFS.Write(buffer, 0, len);
        }
        objFS.Close();
        objResponse.Close();
    }
