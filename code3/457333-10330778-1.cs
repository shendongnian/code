    using (WebClient client = new WebClient())
    {
        client.Credentials = new NetworkCredential(FTP_USR, FTP_PWD);
        client.UploadFile(FTP_PATH + filenameToUpload, filenameToUpload);
    }
