    private static void download()
    {
        int bufferSize = 1024 * 300;
        string filePath = "Test.jpg";
        int bytesRead = 0;
        if (File.Exists(filePath))
            File.Delete(filePath);
        int totalBytes = 0;
        HttpWebRequest webRequest =
            (HttpWebRequest)
            HttpWebRequest.Create(
                @"http://cdn.adnxs.com/p/98/f6/af/4a/98f6af4af7724ff5419ae27726649875.jpg");
        long contentLength = webRequest.GetResponse().ContentLength;
        Console.WriteLine(totalBytes);
        using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
        using (Stream reader = webResponse.GetResponseStream())
        using (BinaryWriter fileWriter = new BinaryWriter(File.Create(filePath)))
        {
            byte[] buffer = new byte[bufferSize];
            do
            {
                bytesRead = reader.Read(buffer, 0, bufferSize); // also tried with Read(buffer, 0, bufferSize);
                fileWriter.Write(buffer, 0, bytesRead);
    
            } while (bytesRead > 0);
        }
    }
