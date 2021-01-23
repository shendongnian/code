    using (var s = new ZipInputStream(download) 
    {
    	ZipEntry theEntry;
    	while ((theEntry = s.GetNextEntry()) != null) 
    	{
    		string directoryName = Path.GetDirectoryName(theEntry.Name);
    		string fileName      = Path.GetFileName(theEntry.Name);
    		
    		if(fileName == myFileName)
    		{
    			using (FileStream streamWriter = File.Create(theEntry.Name)) 
    			{
    				int size = 2048;
    				byte[] data = new byte[2048];
    				while (true) 
    				{
    					size = s.Read(data, 0, data.Length);
    					if (size > 0) 
    					{
    						streamWriter.Write(data, 0, size);
    					} 
    					else 
    					{
    						break;
    					}
    				}
    			}
    		}
    	}
    }
