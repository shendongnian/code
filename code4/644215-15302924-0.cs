    var wc = new WebClient();
    var bytes = wc.DownloadData(new Uri(@"http://api.stackoverflow.com/1.1/questions"));
    string responseText;
    using (var outputStream = new MemoryStream())
    {
    	using (var memoryStream = new MemoryStream(bytes))
    	{
    		using (var gzip = new GZipStream(memoryStream, CompressionMode.Decompress))
    		{
    			byte[] buffer = new byte[1024];
    			int numBytes;
    			while ((numBytes = gzip.Read(buffer, 0, buffer.Length)) > 0)
    			{
    				outputStream.Write(buffer, 0, numBytes);
    			}
    		}
    		responseText = Encoding.UTF8.GetString(outputStream.ToArray());
    	}
    }
    
    Console.WriteLine(responseText);
