    private static void download()
    {
        int bufferSize = 1024 * 300;
        string filePath = "Test.exe";
    
        if (File.Exists(filePath))
            File.Delete(filePath);
        int totalBytes = 0;
        HttpWebRequest webRequest =
            (HttpWebRequest)
            HttpWebRequest.Create(
                @"http://www.rarlab.com/rar/wrar420.exe");
        long contentLength = webRequest.GetResponse().ContentLength;
        Console.WriteLine(totalBytes);
    
        using (WebResponse webResponse = webRequest.GetResponse())
        using (Stream reader = webResponse.GetResponseStream())
        using (BinaryWriter fileWriter = new BinaryWriter(File.Create(filePath)))
        {
            int bytesRead = 0;
            byte[] buffer = new byte[bufferSize];
            do
            {
                bytesRead = reader.Read(buffer, 0, buffer.Length);
                totalBytes += bytesRead;
                fileWriter.Write(buffer, 0, bytesRead);
                Console.WriteLine("BytesRead: " + bytesRead + " -- TotalBytes: " + totalBytes);
    
            } while (bytesRead > 0);
        }
    }
