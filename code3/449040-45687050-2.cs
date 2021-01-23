        const string uri = "ftp://example.com/remote/path/file.txt";
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
        request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        Console.WriteLine("{0} {1}", uri, response.LastModified);
        if (response.LastModified > DateTime.Now.Subtract(TimeSpan.FromHours(1)))
        {
            // download
        }
