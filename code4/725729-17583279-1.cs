    result = new MemoryStream();
    
    using (ZipFile zipFile = new ZipFile())
    {
    	List<IDisposable> memStreams = new List<IDisposable>();
    	try
    	{
    		for (int i = 0; i < files.Count(); i++)
    		{
    			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
    			Byte[] bytes = encoding.GetBytes(files[i]);
    			MemoryStream fs = new MemoryStream(bytes);
    			zipFile.AddEntry(fileNames[i], fs);
    			memStreams.Add(fs);
    		}
    		zipFile.Save(result);
    	}
    	finally
    	{
    		foreach(var x in memStreams)
    		{
    			x.Dispose();
    		}
    	}
    }
