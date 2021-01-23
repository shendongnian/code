    private void Download(string fileName, string ftpServerIP, string ftpUserID, string ftpPassword, string outputName)
    {
        using(WebClient request = new WebClient())
        {
            request.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            byte[] fileData = request.DownloadData(string.Format("ftp://{0}{1}", ftpServerIP, filename));
            using(FileStream file = File.Create(Server.MapPath(outputName)))
            {
                file.Write(fileData, 0, fileData.Length);
            }
        }
    }
