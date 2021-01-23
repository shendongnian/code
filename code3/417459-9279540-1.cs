    using (var outFile = File.Create(outputFileName))
    {
    	using (GZipStream gzip = new GZipStream(download, CompressionMode.Decompress))
    	{
    		var buffer = new byte[4096];
    		var numRead = 0;
    		while ((numRead = gzip.Read(buffer, 0, buffer.Length)) != 0)
    		{
    			outFile.Write(buffer, 0, numRead);
    		}
    	}
    }
