    public void AsyncCallback(IAsyncResult result)
    {
        HttpWebRequest request = result.AsyncState as HttpWebRequest;	
        using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result))
        using (Stream stream = response.GetResponseStream())
        {
            var buffer = new byte[2048];
            while(stream.CanRead)
            {
                var readCount = stream.Read(buffer, 0, buffer.Length);
                var line = Encoding.UTF8.GetString(buffer.Take(readCount).ToArray());
                Console.WriteLine(line);
            }
        }
    }
