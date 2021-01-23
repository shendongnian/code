    // Get the request which was made from StartStream
    HttpWebRequest request = result.AsyncState as HttpWebRequest;
                
    // Create a streamreader to read from the stream http
    using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result))
    using (Stream stream = response.GetResponseStream())
    using (MemoryStream memory = new MemoryStream())
    using (GZipStream gzip = new GZipStream(memory, CompressionMode.Decompress))
    using (StreamReader reader = new StreamReader(gzip))
    {
        byte[] buffer = new byte[32768];
        while (stream.CanRead)
        {
            int readCount = stream.Read(buffer, 0, buffer.Length);
                        
            memory.Write(buffer.Take(readCount).ToArray(), 0, readCount);
            memory.Position = memory.Position - readCount;
            string line = reader.ReadLine();
            if (!string.IsNullOrEmpty(line))
                Console.WriteLine(line);
        }
    }
