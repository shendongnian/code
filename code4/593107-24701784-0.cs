    public static IEnumerable<string> GetFilesInFtpDirectory(string url, string username, string password)
    {
        // Get the object used to communicate with the server.
        var request = (FtpWebRequest)WebRequest.Create(url);
        request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        request.Credentials = new NetworkCredential(username,password);
        using (var response = (FtpWebResponse) request.GetResponse())
        {
            using (var responseStream = response.GetResponseStream())
            {
                var reader = new StreamReader(responseStream);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line) == false)
                    {
                        yield return line.Split(new[] { ' ', '\t' }).Last();    
                    }
                }
            }
        }
    }
