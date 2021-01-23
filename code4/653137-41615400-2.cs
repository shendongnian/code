    public static MemoryStream downloadFile(string url, Int64 fileMaxKbSize = 1024)
    {
        try
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.KeepAlive = true;
            webRequest.Method = "GET";
    
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Int64 fileSize = webResponse.ContentLength;
            if (fileSize < fileMaxKbSize * 1024)
            {
                // Download the file
                Stream receiveStream = webResponse.GetResponseStream();
                MemoryStream m = new MemoryStream();
    
                byte[] buffer = new byte[1024];
    
                int bytesRead;
                while ((bytesRead = receiveStream.Read(buffer, 0, buffer.Length)) != 0 && bytesRead <= fileMaxKbSize * 1024)
                {
                    m.Write(buffer, 0, bytesRead);
                }
    
                // Or using statement instead
                m.Position = 0;
    
                webResponse.Close();
                return m;
            }
            return null;
        }
        catch (Exception ex)
        {
            // proper handling
        }
    
        return null;
    }
