    private void DownloadFile(string[] fileList, string destination)
    {
        var myCred = new NetworkCredential(_remoteUser, _remotePass);
        for (int i = 2; i <= fileList.Length - 1; i++)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_remoteHost + fileList[i]);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = myCred;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            StreamWriter writer = new StreamWriter(destination + fileList[i]);
            writer.Write(reader.ReadToEnd());
            writer.Close();
            reader.Close();
            response.Close();
    }
}
