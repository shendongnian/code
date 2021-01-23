    private static void DownloadCurrent()
    {
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("[url to download]");
        webRequest.Method = "GET";
        webRequest.Timeout = 3000;
        webRequest.BeginGetResponse(new AsyncCallback(PlayResponeAsync), webRequest);
    }
    private static void PlayResponeAsync(IAsyncResult asyncResult)
    {
        long total = 0;
        long received = 0;
        HttpWebRequest webRequest = (HttpWebRequest)asyncResult.AsyncState;
      
        try
        {                    
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asyncResult))
            {
                byte[] buffer = new byte[1024];
                FileStream fileStream = File.OpenWrite("[file name to write]");
                using (Stream input = webResponse.GetResponseStream())
                {        
                    total = input.Length;
           
                    int size = input.Read(buffer, 0, buffer.Length);
                    while (size > 0)
                    {
                        fileStream.Write(buffer, 0, size);
                        received += size;
                        size = input.Read(buffer, 0, buffer.Length);
                    }
                }
                fileStream.Flush();
                fileStream.Close();
            }                 
        }
        catch (Exception ex)
        {
        }
    }
