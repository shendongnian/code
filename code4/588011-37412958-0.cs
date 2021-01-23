    if (!Directory.Exists(localFolder))
    {
        Directory.CreateDirectory(localFolder);   
    }
    
    
    try
    {
        HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(Path.Combine(uri, filename));
        httpRequest.Method = "GET";
    
        // if the URI doesn't exist, exception gets thrown here...
        using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
        {
            using (Stream responseStream = httpResponse.GetResponseStream())
            {
                using (FileStream localFileStream = 
                    new FileStream(Path.Combine(localFolder, filename), FileMode.Create))
                {
                    var buffer = new byte[4096];
                    long totalBytesRead = 0;
                    int bytesRead;
    
                    while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        totalBytesRead += bytesRead;
                        localFileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {        
        throw;
    }
